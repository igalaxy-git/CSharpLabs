using System.Text.Json;
using System.Xml.Serialization;

namespace Lab3.Commands;

public class Open:IInitCommand
{
    public string Key => "o";
    
    public static void Init(IDictionary<string, ICommand> dict)
    {
        var command = new Open();
        dict.Add(command.Key,command);
    }

    private Open(){}

    public void do_command()
    {
        Console.WriteLine("1. Json");
        Console.WriteLine("2. Xml");
        Console.WriteLine("3. SQLite");
        var tryParseInput = int.TryParse(Console.ReadLine(), out var input) && (input >= 1 && input <= 3);
        while (!tryParseInput)
        {
            Console.WriteLine("Попробуйте ещё раз.");
            tryParseInput = int.TryParse(Console.ReadLine(), out input) && (input >= 1 && input <= 3);
        }
        int format = input;
        Console.WriteLine("Укажите путь.");
        String path = Console.ReadLine();
        try
        {
            Storage storage = null;
            switch (format)
            {
                // json
                case 1:
                    storage = JsonSerializer.Deserialize<Storage>(File.ReadAllText(path))!;
                    break;
                // xml
                case 2:
                    StreamReader reader = new StreamReader(path);
                    storage = (Storage)new XmlSerializer(typeof(Storage)).Deserialize(reader)!;
                    break;
                // sqlite
                case 3:
                    AppDbContext context = new AppDbContext(path);
                    context.Database.EnsureCreated();
                    storage = new Storage() { Numbers = context.Numbers.ToList() };
                    break;
            }
            Calculator.storage = storage;
            Calculator.CurrentIndex = storage.Numbers.Count - 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}