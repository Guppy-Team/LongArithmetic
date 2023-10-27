namespace LongArithmetic.Core;

public class BigNumber
{
    private List<int> _digits;
    private readonly bool _isNegative;

    public static BigNumber Zero => new BigNumber("0");

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

    private static BigNumber Multiply(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
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
        // Проверяем знаки чисел
        if (left._isNegative && !right._isNegative)
            // Если left отрицательное, а right неотрицательное, то left всегда меньше right.
            return false;
        else if (!left._isNegative && right._isNegative)
            // Если left неотрицательное, а right отрицательное, то left всегда больше right.
            return true;
        else
        {
            // Если оба числа одного знака, сравниваем их посимвольно.
            if (left._digits.Count > right._digits.Count)
                // Если left имеет больше цифр, чем right, то left всегда больше.
                return true;
            else if (left._digits.Count < right._digits.Count)
                // Если right имеет больше цифр, чем left, то left всегда меньше.
                return false;
            else
            {
                // Если количество цифр одинаковое, сравниваем цифры поочередно, начиная с самых старших разрядов.
                for (int i = left._digits.Count - 1; i >= 0; i--)
                {
                    if (left._digits[i] > right._digits[i])
                        // Если очередная цифра left больше соответствующей цифры right, то left больше.
                        return true;
                    else if (left._digits[i] < right._digits[i])
                        // Если очередная цифра left меньше соответствующей цифры right, то left меньше.
                        return false;
                }
                // Если все цифры одинаковы, то числа равны.
                return false;
            }
        }
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
        // Проверяем знаки чисел
        if (left._isNegative && !right._isNegative)
            // Если left отрицательное, а right неотрицательное, то left всегда меньше.
            return true;
        else if (!left._isNegative && right._isNegative)
            // Если left неотрицательное, а right отрицательное, то left всегда больше.
            return false;
        else
        {
            // Если оба числа одного знака, сравниваем их посимвольно.
            if (left._digits.Count > right._digits.Count)
                // Если left имеет больше цифр, чем right, то left всегда больше.
                return false;
            else if (left._digits.Count < right._digits.Count)
                // Если right имеет больше цифр, чем left, то left всегда меньше.
                return true;
            else
            {
                // Если количество цифр одинаковое, сравниваем цифры поочередно, начиная с самых старших разрядов.
                for (int i = left._digits.Count - 1; i >= 0; i--)
                {
                    if (left._digits[i] > right._digits[i])
                        // Если очередная цифра left больше соответствующей цифры right, то left больше.
                        return false;
                    else if (left._digits[i] < right._digits[i])
                        // Если очередная цифра left меньше соответствующей цифры right, то left меньше.
                        return true;
                }
                // Если все цифры одинаковы, то числа равны.
                return false;
            }
        }
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
        // Убираем ведущие нули, если они есть
        while (absDigits.Count > 1 && absDigits[absDigits.Count - 1] == 0)
            absDigits.RemoveAt(absDigits.Count - 1);
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

    // ===== потом =====
    // private bool IsZero()
    // {
    //     return _value.Trim('-') == "0";
    // }
    //
    // public override string ToString()
    // {
    //     if (_isNegative)
    //     {
    //         return "-" + _value;
    //     }
    //
    //     return _value;
    // }

    #endregion
}