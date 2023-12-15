using Lab2.Commands;

namespace CSharpLabs;

using System;

public class Calculator
{
    private static Dictionary<string, ICommand> commandCollection;
    public static List<double> numbers = new List<double>();
    public static int current_index = -1;
    
    public Calculator()
    {
        Instruction();
        
        GetOperand();
        ShowLastNumber();
        
        InitOperators();
        while (true){GetOperator();}
    }

    private static void Instruction()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("when a first symbol on line is ‘>’ – enter operand (number)");
        Console.WriteLine("when a first symbol on line is ‘@’ – enter operation");
        Console.WriteLine("operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or");
        Console.WriteLine("‘#’ followed with number of evaluation step");
        Console.WriteLine("‘q’ to exit");
    }

    public static double GetOperand()
    {
        Console.Write("> ");
        var tryParseInput = double.TryParse(Console.ReadLine(), out var input);
        while (!tryParseInput)
        {
            Console.WriteLine("Это не число! Попробуйте ещё раз.");
            Console.Write("> ");
            tryParseInput = double.TryParse(Console.ReadLine(), out input);
        }

        numbers.Add(input);
        current_index += 1;
        return input;
    }

    public static void ShowLastNumber()
    {
        Console.WriteLine("[#" + (current_index + 1) + "] = " + numbers[current_index]);
    }
    
    public static void InitOperators()
    {
        commandCollection = new Dictionary<string, ICommand>();
        Plus.Init(commandCollection);
        Minus.Init(commandCollection);
        Multiply.Init(commandCollection);
        Divide.Init(commandCollection);
        Quit.Init(commandCollection);
    }
    public static void GetOperator()
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
                //Console.WriteLine(e);
                Console.WriteLine("Невозможная операция!");
            }

        else if (input[0] == '#')
        {
            try
            {
                int index = Convert.ToInt16(input.Substring(1));
                Console.WriteLine(input + " = " + numbers[index-1]);
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

        