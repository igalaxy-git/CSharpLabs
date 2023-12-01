namespace CSharpLabs;

class Program
{
    private static int current_index = 0;
    private static double current_operand = 0;
    private static int current_operation = -1; // 0 = +; 1 = -; 2 = *; 3 = /
    private static List<double> numbers;
    
    public static void Main()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("when a first symbol on line is ‘>’ – enter operand (number)");
        Console.WriteLine("when a first symbol on line is ‘@’ – enter operation");
        Console.WriteLine("operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or");
        Console.WriteLine("‘#’ followed with number of evaluation step");
        Console.WriteLine("‘q’ to exit");

        numbers = new List<double>();

        while (true)
        {
            GetOperand();
            Console.WriteLine(current_operand);
            GetOperation();
        }

    }

    private static void GetOperand()
    {
        Console.Write("> ");
        var tryParseInput = double.TryParse(Console.ReadLine(), out var input);
        while (!tryParseInput)
        {
            Console.WriteLine("Это не число! Попробуйте ещё раз.");
            Console.Write("> ");
            tryParseInput = double.TryParse(Console.ReadLine(), out input);
        }
        
        if (current_index == 0)
        {
            current_operand = input;
        }
        else
        {
            switch (current_operation)
            {
                case 0:
                    current_operand += input;
                    break;
                case 1:
                    current_operand -= input;
                    break;
                case 2:
                    current_operand *= input;
                    break;
                case 3:
                    current_operand /= input;
                    break;
            }
        }
        current_index += 1;
        numbers.Add(current_operand);
    }

    private static void GetOperation()
    {
        Console.Write("@ ");
        string input = Console.ReadLine();
        switch (input)
        {
            case "":
                Console.WriteLine("Несуществующая операция!");
                GetOperation();
                break;
            case "+":
                current_operation = 0;
                break;
            case "-":
                current_operation = 1;
                break;
            case "*":
                current_operation = 2;
                break;
            case "/":
                current_operation = 3;
                break;
            case "q":
                Environment.Exit(0);
                break;
            default:
                if (input[0] == '#')
                {
                    try
                    {
                        int index = Convert.ToInt16(input.Substring(1));
                        Console.WriteLine(input + ": " + numbers[index]);
                        GetOperation();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Несуществующая операция!");
                        GetOperation();
                    }
                }
                else
                {
                    Console.WriteLine("Несуществующая операция!");
                    GetOperation();
                }
                break;
        }
    }
    
}

