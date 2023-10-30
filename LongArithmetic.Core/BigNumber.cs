using System.Text;

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
        _isNegative = !digits.SequenceEqual(new List<int>(0)) && isNegative;
        RemoveLeadingZeros();
    }

    private BigNumber()
    {
        _digits = new List<int> { 0 };
        _isNegative = false;
    }

    #region Операторы

    public static BigNumber operator +(BigNumber left, BigNumber right)
    {
        int l = (int) left;
        int r = (int) right;
        int result = l + r;
        return new BigNumber(result.ToString());
    }
    
    public static BigNumber operator +(BigNumber left, int right)
    {
        int l = (int) left;
        int result = l + right;
        return new BigNumber(result.ToString());
    }

    public static BigNumber operator -(BigNumber left, BigNumber right)
    {
        int l = (int) left;
        int r = (int) right;
        int result = l - r;
        return new BigNumber(result.ToString());
    }

    public static BigNumber operator *(BigNumber left, BigNumber right)
    {
        return Multiply(left, right);
    }

    public static BigNumber operator /(BigNumber left, BigNumber right)
    {
        return Divide(left, right);
    }
    
    public static bool operator <=(BigNumber left, BigNumber right)
    {
        int l = (int) left;
        int r = (int) right;
        return l <= r;
    }
    
    public static bool operator >=(BigNumber left, BigNumber right)
    {
        int l = (int) left;
        int r = (int) right;
        return l >= r;
    }
    
    public static bool operator >(BigNumber left, BigNumber right)
    {
        return GreaterThan(left, right);
    }
    
    public static bool operator ==(BigNumber left, BigNumber right)
    {
        if (BigNumber.GreaterThan(left, right))
            return false;
        if (BigNumber.LessThan(left, right))
            return false;

        return true;
    }
    
    public static bool operator !=(BigNumber left, BigNumber right)
    {
        int l = (int) left;
        int r = (int) right;
        return l != r;
    }
    
    public static bool operator <(BigNumber left, BigNumber right)
    {
        return LessThan(left, right);
    }

    // Остальные перегрузки сюда

    #endregion

    #region Операции

    public static BigNumber Add(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    public static BigNumber Subtract(BigNumber left, BigNumber right)
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

    
    /// <summary>
    /// Делит одно значение BigNumber на другое и возвращает результат.
    /// </summary>
    /// <param name="dividend">Делимое.</param>
    /// <param name="divisor">Делитель.</param>
    /// <returns>Результат деления.</returns>
    private static BigNumber Divide(BigNumber dividend, BigNumber divisor)
    {
        //! TODO Потом убрать
        // При целочисленном делении вернуть ноль
        if (divisor > dividend)
        {
            return BigNumber.Zero;
        }

        if (dividend == BigNumber.Zero)
        {
            return BigNumber.Zero;
        }
        
        // Если числа равны вернуть единицу
        if (divisor == dividend)
        {
            return BigNumber.One;
        }

        // Получаем знак
        bool isNegative = divisor._isNegative != dividend._isNegative;
        
        // Делаем оба числа положительными
        dividend = BigNumber.Abs(dividend);
        divisor = BigNumber.Abs(divisor);

        // Инициализация листа с частным
        List<int> quotient = new List<int>();
        
        // Индекс для слежения где в процессе деления мы находимся
        int divisionIndex = dividend.Length - 1;
        
        // Процесс деления
        while (divisionIndex >= 0)
        {
            int digit = 0;
            // Временное делимое
            int tempDividend = dividend[divisionIndex];

            if (tempDividend == 0)
            {
                quotient.Insert(0, digit);
                divisionIndex--;
                continue;
            }
            
            int exponent = 10;
            
            // Если временное делимое меньше делителя, то добавляем следующий раздряд
            // Например 12 / 4 => 1 < 4 => добавляем десятки => 12 / 4
            while (tempDividend < divisor)
            {
                tempDividend *= exponent;
                exponent *= 10;
                divisionIndex--;
                tempDividend += dividend[divisionIndex];
            }

            while (tempDividend >= divisor)
            {
                tempDividend -= (int)divisor;
                digit++;
            }
            
            quotient.Insert(0, digit);
            
            divisionIndex--;
        }
        
        return new BigNumber(quotient, isNegative);
    }

    public static BigNumber Mod(BigNumber dividend, BigNumber divisor)
    {
        throw new NotImplementedException();
    }

    // Работоспособность не проверял
    /// <summary>
    /// Метод возводящий одно число в степень другого
    /// </summary>
    /// 
    /// <param name="baseValue">Число</param>
    /// <param name="exponent">Степень</param>
    /// 
    /// <returns>Число, возведенное в степень</returns>
    public static BigNumber Pow(BigNumber baseValue, BigNumber exponent)
    {
        // Если показатель степени равен 0, результат всегда равен 1.
        if (exponent == BigNumber.Zero) 
            return BigNumber.One;

        // Инициализация результата и нуля.
        BigNumber result = BigNumber.One;

        // Пока показатель степени не станет равным нулю
        while (exponent != BigNumber.Zero)
        {
            // Проверяем младший разряд показателя степени
            // Если младший разряд равен 1, умножаем результат на baseValue.
            if (exponent[0] % 2 == 1) result *= baseValue;

            // Возводим baseValue в квадрат (для ускорения операции возведения в степень).
            baseValue *= baseValue;

            // Уменьшаем показатель степени вдвое (сдвигаем разряды вправо).
            exponent /= 2;
        }

        return result;
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

        // Создаем новый объект BigNumber с абсолютным значением
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
        return new BigNumber(value.ToString());
    }

    public static explicit operator int(BigNumber bigInt)
    {
        return int.Parse(bigInt.ToString());
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