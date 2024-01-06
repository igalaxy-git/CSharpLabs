using System.Collections.Generic;

namespace Lab5.Models.Commands;
using Lab5.Views;

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
        MainWindow.storage.Numbers[MainWindow.CurrentIndex] = MainWindow.storage.Numbers[MainWindow.CurrentIndex-1] - MainWindow.storage.Numbers[MainWindow.CurrentIndex];
    }
}