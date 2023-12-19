namespace Lab2.Commands;

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
        Calculator.storage.Numbers[Calculator.CurrentIndex] += Calculator.storage.Numbers[Calculator.CurrentIndex-1];
        Calculator.ShowLastNumber();
    }
}