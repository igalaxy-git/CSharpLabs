using Lab4.Commands;
using System;

namespace Lab4;

public class Calculator
{
    private Dictionary<string, ICommand> commandCollection;
    public Storage storage;
    public int CurrentIndex = -1;
    
    public Calculator()
    {
        ConfigStorage();
        Instruction();
        GetOperand();
        ShowLastNumber();
        InitOperators();
    }

    private void ConfigStorage()
    {
        storage = new Storage() { Numbers = new List<DoubleShell>() };
    }

    private void Instruction()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("when a first symbol on line is ‘>’ – enter operand (number)");
        Console.WriteLine("when a first symbol on line is ‘@’ – enter operation");
        Console.WriteLine("operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or");
        Console.WriteLine("‘#’ followed with number of evaluation step");
        Console.WriteLine("‘o’ to open a file");
        Console.WriteLine("‘s’ to save this file");
        Console.WriteLine("‘q’ to exit");
    }

    public void GetOperand()
    {
        Console.Write("> ");
        var tryParseInput = double.TryParse(Console.ReadLine(), out var input);
        while (!tryParseInput)
        {
            Console.WriteLine("Это не число! Попробуйте ещё раз.");
            Console.Write("> ");
            tryParseInput = double.TryParse(Console.ReadLine(), out input);
        }

        storage.Numbers.Add(new DoubleShell() { Value = input });
        CurrentIndex += 1;
    }

    public void ShowLastNumber()
    {
        Console.WriteLine("[#" + (CurrentIndex + 1) + "] = " + storage.Numbers[CurrentIndex]);
    }
    
    private void InitOperators()
    {
        commandCollection = new Dictionary<string, ICommand>();
        Plus.Init(commandCollection);
        Minus.Init(commandCollection);
        Multiply.Init(commandCollection);
        Divide.Init(commandCollection);
        Quit.Init(commandCollection);
        Open.Init(commandCollection);
        Save.Init(commandCollection);
    }
    public string GetOperator(string i)
    {
        string input = i;

        if (input.Length == 1)
            try
            {
                var command = commandCollection[input];
                command.do_command();
            }
            catch (Exception e)
            {
                return "Невозможная операция!";
            }

        else if (input[0] == '#')
        {
            try
            {
                int index = Convert.ToInt16(input.Substring(1));
                return (input + " = " + storage.Numbers[index-1]);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return "Невозможная операция!";
            }
        }
        else
            return "Невозможная операция!";
    }
}
