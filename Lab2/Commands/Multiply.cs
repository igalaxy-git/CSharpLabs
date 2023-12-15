using CSharpLabs;

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
        double result = Calculator.numbers[Calculator.current_index - 1] * Calculator.numbers[Calculator.current_index];
        if (result.Equals(Double.NaN))
            result = 0;
        Calculator.numbers[Calculator.current_index] = result;
        Calculator.ShowLastNumber();
    }
}