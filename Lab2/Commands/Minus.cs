namespace Lab2.Commands;

public class Minus:IInitCommand
{
    public string Key => "-";
    public static void Init(IDictionary<string, ICommand> dict)
    {
        var command = new Minus();
        dict.Add(command.Key,command);
    }

    private Minus(){}
    
    public void do_command()
    {
        Calculator.GetOperand();
        Calculator.storage.Numbers[Calculator.CurrentIndex] -= Calculator.storage.Numbers[Calculator.CurrentIndex-1];
        Calculator.ShowLastNumber();
    }
}