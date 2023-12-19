using Lab3.Commands;

namespace Lab3;

using System;

public class Calculator
{
    private static Dictionary<string, ICommand> commandCollection;
    public static Storage storage;
    public static int CurrentIndex = -1;
    
    public Calculator()
    {
        ConfigStorage();
        Instruction();
        GetOperand();
        ShowLastNumber();
        InitOperators();
        while (true){GetOperator();}
    }

    private static void ConfigStorage()
    {
        storage = new Storage() { Numbers = new List<DoubleShell>() };
    }

    private static void Instruction()
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

    public static void GetOperand()
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

    public static void ShowLastNumber()
    {
        Console.WriteLine("[#" + (CurrentIndex + 1) + "] = " + storage.Numbers[CurrentIndex]);
    }
    
    private static void InitOperators()
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
    private static void GetOperator()
    {
        Console.Write("@ ");
        string input = Console.ReadLine();

        if (input.Length == 1)
            try
            {
                var command = commandCollection[input];
                command.do_command();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Невозможная операция!");
            }

        else if (input[0] == '#')
        {
            try
            {
                int index = Convert.ToInt16(input.Substring(1));
                Console.WriteLine(input + " = " + storage.Numbers[index-1]);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                Console.WriteLine("Невозможная операция!");
            }
        }
        else
            Console.WriteLine("Невозможная операция!");
    }
}
