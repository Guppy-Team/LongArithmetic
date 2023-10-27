﻿using System.Text;

namespace LongArithmetic.Core;

public class BigNumber
{
    private List<int> _digits;
    private readonly bool _isNegative;

    public static BigNumber Zero => new BigNumber("0");
    public static BigNumber One => new BigNumber("1");

    public int Length
    {
        get => _digits.Count;
    }
    
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= _digits.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return _digits[index];
        }
    }

    public BigNumber(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            _digits = new List<int> { 0 };
            _isNegative = false;
        }
        else
        {
            _isNegative = value[0] == '-';
            int startIndex = _isNegative ? 1 : 0;

            _digits = new List<int>();
            for (int i = value.Length - 1; i >= startIndex; i--)
            {
                if (char.IsDigit(value[i]))
                {
                    _digits.Add(int.Parse(value[i].ToString()));
                }
                else
                {
                    throw new ArgumentException("Значение должно содержать только цифры.");
                }
            }
        }
    }

    private BigNumber(List<int> digits, bool isNegative)
    {
        _digits = digits;
        _isNegative = isNegative;
        RemoveLeadingZeros();
    }

    #region Операторы

    public static BigNumber operator +(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    public static BigNumber operator -(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    public static BigNumber operator *(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    public static BigNumber operator /(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    // Остальные перегрузки сюда

    #endregion

    #region Операции

    private static BigNumber Add(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    private static BigNumber Subtract(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left">Первое число.</param>
    /// <param name="right">Второе число.</param>
    /// <returns>Возвращает результат перемножения двух чисел типа BigNumber.</returns>
    private static BigNumber Multiply(BigNumber left, BigNumber right)
    {
        // Одно из чисел равно 0
        if (left.IsZero() || right.IsZero())
        {
            return BigNumber.Zero;
        }
        
        int resultLength = left.Length + right.Length;
        List<int> result = new List<int>(resultLength);

        // Заполнение нулями
        for (int i = 0; i < resultLength; i++)
        {
            result.Add(0);
        }

        for (int i = 0; i < left.Length; i++)
        {
            int carry = 0;
            for (int j = 0; j < right.Length; j++)
            {
                int product = (left[i] * right[j]) + result[i + j] + carry;
                carry = product / 10;
                result[i + j] = product % 10;
            }
            if (carry > 0)
            {
                result[i + right.Length] += carry;
            }
        }

        bool isNegative = left._isNegative != right._isNegative;

        return new BigNumber(result, isNegative);
    }

    private static BigNumber Divide(BigNumber dividend, BigNumber divisor)
    {
        throw new NotImplementedException();
    }

    public static BigNumber Mod(BigNumber dividend, BigNumber divisor)
    {
        throw new NotImplementedException();
    }

    public static BigNumber Pow(BigNumber baseValue, BigNumber exponent)
    {
        throw new NotImplementedException();
    }

    // реализуем после всего основного
    // public static BigNumber GeneratePrimeNumber(int bitLength)
    // {
    //     throw new NotImplementedException();
    // }

    #endregion

    #region Сравнение

    // Работоспособность не проверял
    /// <summary>
    /// Метод сравнивающий два числа
    /// Возвращает true, если число left больше right
    /// Возвращает false, если число left меньше или равно right
    /// </summary>
    /// 
    /// <param name="left">Первое число</param>
    /// <param name="right">Второе число</param>
    /// 
    /// <returns> true/false </returns>
    public static bool GreaterThan(BigNumber left, BigNumber right)
    {
        // Если left отрицательное, а right неотрицательное, то left всегда меньше.
        if (left._isNegative && !right._isNegative) return false;
        // Если left неотрицательное, а right отрицательное, то left всегда больше.
        if (!left._isNegative && right._isNegative) return true;

        // Если left имеет больше цифр, чем right, то left всегда больше.
        if (left._digits.Count > right._digits.Count) return true;
        // Если right имеет больше цифр, чем left, то left всегда меньше.
        if (left._digits.Count < right._digits.Count) return false;

        // Если количество цифр одинаковое, сравниваем числа посимвольно, начиная с самых старших разрядов.
        for (int i = left._digits.Count - 1; i >= 0; i--)
        {
            // Если очередная цифра left больше соответствующей цифры right, то left больше.
            if (left._digits[i] > right._digits[i]) return true;
            // Если очередная цифра left меньше соответствующей цифры right, то left меньше.
            if (left._digits[i] < right._digits[i]) return false;
        }

        // Если все цифры одинаковы, то числа равны.
        return false;
    }

    // Работоспособность не проверял
    /// <summary>
    /// Метод сравнивающий два числа
    /// Возвращает true, если число left меньше right
    /// Возвращает false, если число left больше или равно right
    /// </summary>
    /// 
    /// <param name="left">Первое число</param>
    /// <param name="right">Второе число</param>
    /// 
    /// <returns> true/false </returns>
    public static bool LessThan(BigNumber left, BigNumber right)
    {
        // Если left отрицательное, а right неотрицательное, то left всегда меньше.
        if (left._isNegative && !right._isNegative) return true;
        // Если left неотрицательное, а right отрицательное, то left всегда больше.
        if (!left._isNegative && right._isNegative) return false;

        // Если left имеет больше цифр, чем right, то left всегда больше.
        if (left._digits.Count > right._digits.Count) return false;
        // Если right имеет больше цифр, чем left, то left всегда меньше.
        if (left._digits.Count < right._digits.Count) return true;

        // Если количество цифр одинаковое, сравниваем числа посимвольно, начиная с самых старших разрядов.
        for (int i = left._digits.Count - 1; i >= 0; i--)
        {
            // Если очередная цифра left больше соответствующей цифры right, то left больше.
            if (left._digits[i] > right._digits[i]) return false;
            // Если очередная цифра left меньше соответствующей цифры right, то left меньше.
            if (left._digits[i] < right._digits[i]) return true;
        }

        // Если все цифры одинаковы, то числа равны.
        return false;
    }

    public static bool EqualTo(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    // Работоспособность не проверял 
    /// <summary>
    /// Метод определяющий модуль числа
    /// </summary>
    /// 
    /// <param name="num">Число</param>
    /// 
    /// <returns>Модуль числа</returns>
    public static BigNumber Abs(BigNumber num)
    {
        // Создаем копию списка цифр, чтобы не изменять исходное число
        List<int> absDigits = new List<int>(num._digits);

        // Создаем новый объект BigNumber с абсолютным значением и тем же знаком
        return new BigNumber(absDigits, false);
    }

    public static BigNumber GreatestCommonDivisor(BigNumber num)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Преобразования

    public int ConvertToInt()
    {
        throw new NotImplementedException();
    }

    public static implicit operator BigNumber(int value)
    {
        throw new NotImplementedException();
    }

    public static explicit operator int(BigNumber bigInt)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region HelperMethods

    /// <summary>
    /// Проверяет является ли число нулём.
    /// </summary>
    /// <returns>Булево значение.</returns>
    private bool IsZero()
    {
        return _digits.ToString()!.Trim('-') == "0";
    }
    
    /// <summary>
    /// Удаляет ведущие нули.
    /// </summary>
    private void RemoveLeadingZeros()
    {
        int firstNonZeroIndex = 0;

        // Находим индекс первого ненулевого элемента
        while (firstNonZeroIndex < _digits.Count && _digits[Length - 1 - firstNonZeroIndex] == 0)
        {
            firstNonZeroIndex++;
        }

        // Если все цифры равны нулю, то оставить один ноль
        if (firstNonZeroIndex == _digits.Count)
        {
            _digits = new List<int> { 0 };
        }
        else
        {
            // Новый лист чисел, уже без ведущих нулей
            _digits = _digits.GetRange(0, _digits.Count - firstNonZeroIndex);
        }
    }
    
    /// <summary>
    /// Переводит числовое значение BigNumber объекта в его эквивалент в виде строки.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        
        if (_isNegative)
            sb.Append('-');

        for (int i = Length - 1; i >= 0; i--)
        {
            sb.Append(_digits[i]);
        }

        return sb.ToString();
    }

    #endregion
}