using System;
using System.Windows.Input;

namespace LongArithmetic.WPF.SimpleMVVM;

/// <summary>
/// Command with a parameter
/// </summary>
/// <typeparam name="T">Type of parameter</typeparam>
public class Command<T> : ICommand
{
    private Action<T> Action;
    private Func<T, bool> Predicate;

    public Command(Action<T> action)
    {
        Action = action;
    }

    public Command(Action<T> action, Func<T, bool> predicate)
    {
        Action = action;
        Predicate = predicate;
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
        if (parameter is T par)
            return Predicate is null ? true : Predicate(par);
        else
            return false;
    }

    public void Execute(object parameter)
    {
        if (parameter is T par)
            Action(par);
    }
}

/// <summary>
/// Command without parameters
/// </summary>
public class Command : ICommand
{
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    private Action Action;
    private Func<bool> Predicate;

    public Command(Action action)
    {
        Action = action;
    }

    public Command(Action action, Func<bool> predicate)
    {
        Action = action;
        Predicate = predicate;
    }

    public bool CanExecute(object parameter)
    {
        return Predicate is null ? true : Predicate();
    }

    public void Execute(object parameter)
    {
        Action();
    }
}