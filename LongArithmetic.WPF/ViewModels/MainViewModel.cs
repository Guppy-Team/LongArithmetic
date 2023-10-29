using System;
using LongArithmetic.Core;
using LongArithmetic.WPF.SimpleMVVM;

namespace LongArithmetic.WPF.ViewModels;

public class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        CmdAdd = new Command(Add);
        CmdSubtract = new Command(Subtract);
        CmdMultiply = new Command(Multiply);
        CmdDivide = new Command(Divide);
        CmdPowerOfTwo = new Command(PowerOfTwo);
        CmdPowerOfThree = new Command(PowerOfThree);
        CmdSwap = new Command(Swap);
        CmdMod = new Command(Mod);
        CmdPow = new Command(Pow);
        CmdResultToX = new Command(ResultToX);
        CmdGeneratePrimeNumber = new Command(GeneratePrimeNumber);
        CmdGcd = new Command(GreatestCommonDivisor);
        CmdLcm = new Command(LowestCommonMultiple);
        CmdFactorial = new Command(Factorial);
        CmdResultToY = new Command(ResultToY);
        CmdClear = new Command(Clear);
    }
    
    // Fields

    #region Fields

    private string _outputText = string.Empty;
    private string _firstTextBoxText = string.Empty;
    private string _secondTextBoxText = string.Empty;

    #endregion
    
    // Properties

    #region Properties

    public string FirstTextBoxText
    {
        get => _firstTextBoxText;
        set => Set(ref _firstTextBoxText, value);
    }
    public string SecondTextBoxText
    {
        get => _secondTextBoxText;
        set => Set(ref _secondTextBoxText, value);
    }
    public string OutputText
    {
        get => _outputText;
        set => Set(ref _outputText, value);
    }

    #endregion
    
    // Methods

    #region Methods
    private void Add()
    {
        try
        {
            BigNumber num1 = new(FirstTextBoxText);
            BigNumber num2 = new(SecondTextBoxText);
            BigNumber result = num1 + num2;
            OutputText = result.ToString(); 
        }
        catch (Exception e)
        {
            OutputText = "Неверный ввод!";
        }
    }
    private void Subtract()
    {
        try
        {
            BigNumber num1 = new(FirstTextBoxText);
            BigNumber num2 = new(SecondTextBoxText);
            BigNumber result = num1 - num2;
            OutputText = result.ToString(); 
        }
        catch (Exception e)
        {
            OutputText = "Неверный ввод!";
        }
    }
    private void Multiply()
    {
        try
        {
            BigNumber num1 = new(FirstTextBoxText);
            BigNumber num2 = new(SecondTextBoxText);
            BigNumber result = num1 * num2;
            OutputText = result.ToString(); 
        }
        catch (Exception e)
        {
            OutputText = "Неверный ввод!";
        }
    }
    private void Divide()
    {
        try
        {
            BigNumber num1 = new(FirstTextBoxText);
            BigNumber num2 = new(SecondTextBoxText);
            BigNumber result = num1 / num2;
            OutputText = result.ToString(); 
        }
        catch (Exception e)
        {
            OutputText = "Неверный ввод!";
        }
    }
    private void PowerOfTwo()
    {
        try
        {
            //BigNumber num = new(FirstTextBoxText);
            //BigNumber result = BigNumber.Pow(num, 2);
            // OutputText = result.ToString(); 
            OutputText = "Степень пока сломана";
        }
        catch (Exception e)
        {
            OutputText = "Неверный ввод!";
        }
    }
    private void PowerOfThree()
    {
        try
        {
            //BigNumber num = new(FirstTextBoxText);
            //BigNumber result = BigNumber.Pow(num, 3);
            // OutputText = result.ToString(); 
            OutputText = "Степень пока сломана";
        }
        catch (Exception e)
        {
            OutputText = "Неверный ввод!";
        }
    }
    private void Swap()
    {
        (FirstTextBoxText, SecondTextBoxText) = (SecondTextBoxText, FirstTextBoxText);
    }
    private void Mod()
    {
        try
        {
            //BigNumber num1 = new(FirstTextBoxText);
            //BigNumber num2 = new(SecondTextBoxText);
            //BigNumber result = BigNumber.Mod(num1, num2);
            //OutputText = result.ToString(); 
        }
        catch (Exception e)
        {
            OutputText = "Неверный ввод!";
        }
    }
    private void Pow()
    {
        try
        {
            // BigNumber num1 = new(FirstTextBoxText);
            // BigNumber num2 = new(SecondTextBoxText);
            // BigNumber result = BigNumber.Pow(num1, num2);
            // OutputText = result.ToString();
            OutputText = "Пока не сделано";
        }
        catch (Exception e)
        {
            OutputText = "Неверный ввод!";
        }
    }
    private void ResultToX()
    {
        (FirstTextBoxText, OutputText) = (OutputText, FirstTextBoxText);
    }
    private void GeneratePrimeNumber()
    {
        OutputText = "Пока не сделано";
    }
    private void GreatestCommonDivisor()
    {
        //BigNumber bigNumber1 = new BigNumber(FirstTextBoxText);
        //BigNumber bigNumber2 = new BigNumber(SecondTextBoxText);
        //BigNumber result = BigNumber.GreatestCommonDivisor(bigNumber1, bigNumber2);
        //OutputText = result.ToString();
        OutputText = "Пока не сделано";
    }
    private void LowestCommonMultiple()
    {
        //BigNumber bigNumber1 = new BigNumber(FirstTextBoxText);
        //BigNumber bigNumber2 = new BigNumber(SecondTextBoxText);
        //BigNumber result = BigNumber.LowestCommonMultiple(bigNumber1, bigNumber2);
        //OutputText = result.ToString();
        OutputText = "Пока не сделано";
    }
    private void Factorial()
    {
        //BigNumber bigNumber = new BigNumber(FirstTextBoxText);
        //BigNumber result = BigNumber.Factorial(bigNumber);
        //OutputText = result.ToString();
        OutputText = "Пока не сделано";
    }
    private void ResultToY()
    {
        (SecondTextBoxText, OutputText) = (OutputText, SecondTextBoxText);
    }
    private void Clear()
    {
        FirstTextBoxText = string.Empty;
        SecondTextBoxText = string.Empty;
        OutputText = string.Empty;
    }
    
    #endregion
    
// Commands

    #region Commands

    public Command CmdAdd { get; }
    public Command CmdSubtract { get; }
    public Command CmdMultiply { get; }
    public Command CmdDivide { get; }
    public Command CmdPowerOfTwo { get; }
    public Command CmdPowerOfThree { get; }
    public Command CmdSwap { get; }
    public Command CmdMod { get; }
    public Command CmdPow { get; }
    public Command CmdResultToX { get; }
    public Command CmdGeneratePrimeNumber { get; }
    public Command CmdGcd { get; }
    public Command CmdLcm { get; }
    public Command CmdFactorial { get; }
    public Command CmdResultToY { get; }
    public Command CmdClear { get; }
    
    #endregion

}