using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Commands;

public class Save:IInitCommand
{
    public string Key => "s";
    
    public static void Init(IDictionary<string, ICommand> dict)
    {
        var command = new Save();
        dict.Add(command.Key,command);
    }

    private Save(){}

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
            switch (format)
            {
                // json
                case 1:
                    File.WriteAllText(path, JsonSerializer.Serialize(Calculator.storage));
                    break;
                // xml
                case 2:
                    StreamWriter writer = new StreamWriter(path);
                    new XmlSerializer(typeof(Storage)).Serialize(writer, Calculator.storage);
                    break;
                // sqlite
                case 3:
                    AppDbContext context = new AppDbContext(path);
                    context.Database.EnsureCreated();
                    context.Numbers.ExecuteDelete();
                    context.Numbers.AddRange(Calculator.storage.Numbers);
                    context.SaveChanges();
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}