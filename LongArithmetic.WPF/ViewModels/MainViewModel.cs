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
    }
    
    // Fields

    private string _outputText = string.Empty;
    private string _firstTextBoxText = string.Empty;
    private string _secondTextBoxText = string.Empty;
    
    // Properties
    
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
    
    // Methods

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
    
// Commands

    public Command CmdAdd { get; set; }
    public Command CmdSubtract { get; set; }
    public Command CmdMultiply { get; set; }
    public Command CmdDivide { get; set; }
}