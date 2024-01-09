using System;
using System.Collections.Generic;
using Lab5.Views;
namespace Lab5.Models.Commands;

public class Divide:IInitCommand
{
    public string Key => "/";
    public static void Init(IDictionary<string, ICommand> dict)
    {
        var command = new Divide();
        dict.Add(command.Key,command);
    }

    private Divide(){}
    
    public void do_command()
    {
        double result = MainWindow.storage.Numbers[MainWindow.CurrentIndex - 1] / MainWindow.storage.Numbers[MainWindow.CurrentIndex];
        if (result.Equals(Double.NaN))
            result = 0;
        MainWindow.storage.Numbers[MainWindow.CurrentIndex] = result;
    }
}