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

    # region Сравнение

    public static bool GreaterThan(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool LessThan(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool EqualTo(BigNumber left, BigNumber right)
    {
        throw new NotImplementedException();
    }

    public static BigNumber Abs(BigNumber num)
    {
        throw new NotImplementedException();
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