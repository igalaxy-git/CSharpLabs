using System.Collections.Generic;
using Lab5.Views;

namespace Lab5.Models.Commands;

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
        MainWindow.storage.Numbers[MainWindow.CurrentIndex] += MainWindow.storage.Numbers[MainWindow.CurrentIndex-1];
    }
}