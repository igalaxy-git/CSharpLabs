namespace Lab2.Commands;

public class Multiply:IInitCommand
{
    public string Key => "*";
    public static void Init(IDictionary<string, ICommand> dict)
    {
        var command = new Multiply();
        dict.Add(command.Key,command);
    }

    private Multiply(){}
    
    public void do_command()
    {
        Calculator.GetOperand();
        double result = Calculator.storage.Numbers[Calculator.CurrentIndex - 1] * Calculator.storage.Numbers[Calculator.CurrentIndex];
        if (result.Equals(Double.NaN))
            result = 0;
        Calculator.storage.Numbers[Calculator.CurrentIndex] = result;
        Calculator.ShowLastNumber();
    }
}