namespace Lab3.Commands;

public class Plus:IInitCommand
{
    public string Key => "+";
    public static void Init(IDictionary<string, ICommand> dict)
    {
        var command = new Plus();
        dict.Add(command.Key,command);
    }

    private Plus(){}
    
    public void do_command()
    {
        Calculator.GetOperand();
        double result = Calculator.storage.Numbers[Calculator.CurrentIndex - 1].Value + Calculator.storage.Numbers[Calculator.CurrentIndex].Value;
        Calculator.storage.Numbers[Calculator.CurrentIndex] = new DoubleShell() { Value = result };
        Calculator.ShowLastNumber();
    }
}