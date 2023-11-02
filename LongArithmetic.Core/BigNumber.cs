using System.Text;

namespace LongArithmetic.Core;

public class BigNumber
{
    private List<int> Digits { get; set; }
    
    private bool IsNegative { get; }

    public static BigNumber Zero => new BigNumber("0");
    public static BigNumber One => new BigNumber("1");

    public int Length
    {
        get => Digits.Count;
    }
    
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= Digits.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return Digits[index];
        }
    }

    public BigNumber(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            Digits = new List<int> { 0 };
            IsNegative = false;
        }
        else
        {
            IsNegative = value[0] == '-';
            int startIndex = IsNegative ? 1 : 0;

            Digits = new List<int>();
            for (int i = value.Length - 1; i >= startIndex; i--)
            {
                if (char.IsDigit(value[i]))
                {
                    Digits.Add(int.Parse(value[i].ToString()));
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
        Digits = digits;
        this.IsNegative = !digits.SequenceEqual(new List<int>(0)) && isNegative;
        
        RemoveLeadingZeros();
        
        if(Digits.Count == 1 && Digits[0] == 0)
            this.IsNegative = false;
    }

    private BigNumber()
    {
        Digits = new List<int> { 0 };
        IsNegative = false;
    }

    #region Операторы

    public static BigNumber operator +(BigNumber left, BigNumber right)
    {
        return Add(left, right);
    }
    
    public static BigNumber operator +(BigNumber left, int right)
    {
        BigNumber r = new BigNumber(right.ToString());
        BigNumber result = left + r;
        return new BigNumber(result.ToString());
    }

    public static BigNumber operator -(BigNumber left, BigNumber right)
    {
        return Subtract(left, right);
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
        return ((left < right) || (left == right));
    }
    
    public static bool operator >=(BigNumber left, BigNumber right)
    {
        return ((left > right) || (left == right));
    }
    
    public static bool operator >(BigNumber left, BigNumber right)
    {
        return GreaterThan(left, right);
    }
    
    public static bool operator ==(BigNumber left, BigNumber right)
    {
        return !(left > right) && !(left < right);
    }
    
    public static bool operator !=(BigNumber left, BigNumber right)
    {
        return !(left == right);
    }
    
    public static bool operator <(BigNumber left, BigNumber right)
    {
        return LessThan(left, right);
    }

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
            return Zero;
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

        bool isNegative = left.IsNegative != right.IsNegative;

        return new BigNumber(result, isNegative);
    }

    
    /// <summary>
    /// Делит одно значение BigNumber на другое и возвращает результат.
    /// </summary>
    /// <param name="dividend">Делимое.</param>
    /// <param name="divisor">Делитель.</param>
    /// <returns>Результат деления.</returns>
    public static BigNumber Divide(BigNumber left, BigNumber right)
    {
        if (right.CompareTo(BigNumber.Zero) == 0)
        {
            throw new DivideByZeroException();
        }

        if (left.IsNegative && !right.IsNegative)
        {
            return Divide(left.Negate(), right).Negate();
        }
        else if (!left.IsNegative && right.IsNegative)
        {
            return Divide(left, right.Negate()).Negate();
        }
        else if (left.IsNegative && right.IsNegative)
        {
            return Divide(left.Negate(), right.Negate());
        }

        BigNumber quotient = BigNumber.Zero;
        BigNumber remainder = BigNumber.Zero;

        for (int i = left.Digits.Count - 1; i >= 0; i--)
        {
            remainder = remainder.MultiplyBy10();
            remainder = Add(remainder, new BigNumber(left.Digits[i].ToString()));

            int digit = 0;

            while (remainder.CompareTo(right) >= 0)
            {
                remainder = Subtract(remainder, right);
                digit++;
            }

            quotient = quotient.MultiplyBy10();
            quotient = Add(quotient, new BigNumber(digit.ToString()));
        }

        return quotient;
    }
    
    /// <summary>
    /// Сравнивает два числа типа BigNumber.
    /// </summary>
    /// <param name="other">Число, с которым сравнить.</param>
    /// <returns>
    /// Возвращает -1 если первое число меньше, 1 если первое число больше, и 0, если они равны
    /// </returns>
    public int CompareTo(BigNumber other)
    {
        if (this.IsNegative && !other.IsNegative)
        {
            return -1;
        }

        if (!this.IsNegative && other.IsNegative)
        {
            return 1;
        }

        int maxLength = Math.Max(this.Digits.Count, other.Digits.Count);

        for (int i = maxLength - 1; i >= 0; i--)
        {
            int digit1 = i < this.Digits.Count ? this.Digits[i] : 0;
            int digit2 = i < other.Digits.Count ? other.Digits[i] : 0;

            if (digit1 < digit2)
                return -1;

            if (digit1 > digit2)
                return 1;
        }

        return 0;
    }
    
    private BigNumber MultiplyBy10()
    {
        var ten = new BigNumber(new List<int>
        {
            0, 1
        }, false);
        return Multiply(this, ten);
    }
    
    public BigNumber Negate()
    {
        return new BigNumber(Digits, !IsNegative);
    }

    /// <summary>
    /// Вычисляет остаток от деления данного числа на указанное число
    /// </summary>
    /// <param name="dividend"></param>
    /// <param name="divisor"></param>
    /// <returns>Остаток от деления</returns>
    public static BigNumber Mod(BigNumber dividend, BigNumber divisor)
    {
        //Находим частное от деления
        BigNumber quotient = dividend / divisor;

        //Возвращаем остаток
        return dividend - (divisor * quotient);
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
        while(exponent.CompareTo(Zero) != 0)
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

    #endregion

    #region Сравнение

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
        if (left.IsNegative && !right.IsNegative) return false;
        // Если left неотрицательное, а right отрицательное, то left всегда больше.
        if (!left.IsNegative && right.IsNegative) return true;

        // Если left имеет больше цифр, чем right, то left всегда больше.
        if (left.Digits.Count > right.Digits.Count) return true;
        // Если right имеет больше цифр, чем left, то left всегда меньше.
        if (left.Digits.Count < right.Digits.Count) return false;

        // Если количество цифр одинаковое, сравниваем числа посимвольно, начиная с самых старших разрядов.
        for (int i = left.Digits.Count - 1; i >= 0; i--)
        {
            // Если очередная цифра left больше соответствующей цифры right, то left больше.
            if (left.Digits[i] > right.Digits[i]) return true;
            // Если очередная цифра left меньше соответствующей цифры right, то left меньше.
            if (left.Digits[i] < right.Digits[i]) return false;
        }

        // Если все цифры одинаковы, то числа равны.
        return false;
    }

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
        if (left.IsNegative && !right.IsNegative) return true;
        // Если left неотрицательное, а right отрицательное, то left всегда больше.
        if (!left.IsNegative && right.IsNegative) return false;

        // Если left имеет больше цифр, чем right, то left всегда больше.
        if (left.Digits.Count > right.Digits.Count) return false;
        // Если right имеет больше цифр, чем left, то left всегда меньше.
        if (left.Digits.Count < right.Digits.Count) return true;

        // Если количество цифр одинаковое, сравниваем числа посимвольно, начиная с самых старших разрядов.
        for (int i = left.Digits.Count - 1; i >= 0; i--)
        {
            // Если очередная цифра left больше соответствующей цифры right, то left больше.
            if (left.Digits[i] > right.Digits[i]) return false;
            // Если очередная цифра left меньше соответствующей цифры right, то left меньше.
            if (left.Digits[i] < right.Digits[i]) return true;
        }

        // Если все цифры одинаковы, то числа равны.
        return false;
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
        List<int> absDigits = new List<int>(num.Digits);

        // Создаем новый объект BigNumber с абсолютным значением
        return new BigNumber(absDigits, false);
    }

    public static BigNumber GreatestCommonDivisor(BigNumber dividend, BigNumber divisor)
    {
        while (divisor != 0)
        {
            //Схраняем делитель во временной переменной
            BigNumber temp = divisor; 
            //Находим остаток от деления
            divisor = BigNumber.Mod(dividend, divisor);
            //Заменяем делимое делителем
            dividend = temp;
        }

        return Abs(dividend);
    }

    #endregion

    #region Преобразования

    /// <summary>
    /// Преобразует текущий объект BigNumber в его целочисленное представление
    /// </summary>
    /// <returns>Целочисленное значение, соответствующее текущему объекту BigNumber</returns>
    public int ConvertToInt()
    {
        // Инициализируем результат нулем
        int result = 0;

        // Проходимся по разрядам справа налево
        for (int i = Digits.Count - 1; i >= 0; i--)
        {
            // Умножаем текущий разряд на 10 в соответствующей степени и прибавляем к результату
            result = result * 10 + Digits[i];
        }

        // Если число отрицательное, умножаем результат на -1
        return IsNegative ? -result : result;
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
        return Digits.ToString()!.Trim('-') == "0";
    }
    
    /// <summary>
    /// Удаляет ведущие нули.
    /// </summary>
    private void RemoveLeadingZeros()
    {
        int firstNonZeroIndex = 0;

        // Находим индекс первого ненулевого элемента
        while (firstNonZeroIndex < Digits.Count && Digits[Length - 1 - firstNonZeroIndex] == 0)
        {
            firstNonZeroIndex++;
        }

        // Если все цифры равны нулю, то оставить один ноль
        if (firstNonZeroIndex == Digits.Count)
        {
            Digits = new List<int> { 0 };
        }
        else
        {
            // Новый лист чисел, уже без ведущих нулей
            Digits = Digits.GetRange(0, Digits.Count - firstNonZeroIndex);
        }
    }
    
    /// <summary>
    /// Переводит числовое значение BigNumber объекта в его эквивалент в виде строки.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        
        if (IsNegative)
            sb.Append('-');

        for (int i = Length - 1; i >= 0; i--)
        {
            sb.Append(Digits[i]);
        }

        return sb.ToString();
    }

    #endregion
}