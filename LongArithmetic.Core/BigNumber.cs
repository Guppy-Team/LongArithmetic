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
        if (exponent.Equals(new BigNumber("0"))) return new BigNumber("1");

        // Инициализация результата и нуля.
        BigNumber result = new BigNumber("1");
        BigNumber zero = new BigNumber("0");

        // Пока показатель степени не станет равным нулю
        while (!exponent.Equals(zero))
        {
            // Проверяем младший разряд показателя степени
            // Если младший разряд равен 1, умножаем результат на baseValue.
            if (exponent._digits[0] % 2 == 1) result *= baseValue;

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