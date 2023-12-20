namespace Lab3.Commands;

public class Divide:IInitCommand
{
    public string Key => "/";
    public static void Init(IDictionary<string, ICommand> dict)
    {
        var command = new Divide();
        dict.Add(command.Key,command);
    }

    private Divide(){}
    
    public void do_command()
    {
        Calculator.GetOperand();
        double result = Calculator.storage.Numbers[Calculator.CurrentIndex - 1].Value / Calculator.storage.Numbers[Calculator.CurrentIndex].Value;
        if (result.Equals(Double.NaN))
            result = 0;
        Calculator.storage.Numbers[Calculator.CurrentIndex] = new DoubleShell() { Value = result };
        Calculator.ShowLastNumber();
    }
}