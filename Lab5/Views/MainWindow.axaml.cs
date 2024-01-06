using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Lab5.Models;
using Lab5.Models.Commands;

namespace Lab5.Views;

public partial class MainWindow : Window
{
    private ICommand command;
    private static Dictionary<string, ICommand> commandCollection;
    public static Storage storage;
    public static int CurrentIndex = -1;
    public Boolean Operand = true;
    
    public MainWindow()
    {
        InitializeComponent();
        storage = new Storage() { Numbers = new List<double>() };
        commandCollection = new Dictionary<string, ICommand>();
        Plus.Init(commandCollection);
        Minus.Init(commandCollection);
        Multiply.Init(commandCollection);
        Divide.Init(commandCollection);
        Nothing.Init(commandCollection);
        command = commandCollection["__nothing__"];
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Operand)
        {
            if (IsDoubleRealNumber(Input.Text))
            {
                storage.Numbers.Add(Convert.ToDouble(Input.Text));
                CurrentIndex += 1;
                command.do_command();
                Output.Text = ShowLastNumber();
                Operand = false;
                Instruction.Text = "Enter an operator:";
            }
            else Output.Text = "Not a number!";
        }
        else
        {
            string input = Input.Text;

            if (input.Length == 1)
                try
                {
                    command = commandCollection[input];
                    Output.Text = "Waiting for a number...";
                    Operand = true;
                    Instruction.Text = "Enter a number:";
                }
                catch (Exception ex)
                {
                    Output.Text = "Error!";
                }

            else if (input[0] == '#')
            {
                try
                {
                    int index = Convert.ToInt16(input.Substring(1));
                    Output.Text = input + " = " + storage.Numbers[index-1];
                    Operand = true;
                    Instruction.Text = "Enter a number:";
                    command = commandCollection["__nothing__"];
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    Output.Text = "Error!";
                }
            }
            else
                Output.Text = "Error!";
        }
        Input.Text = "";
    }
    
    public static bool IsDoubleRealNumber(string valueToTest)
    {
        if (double.TryParse(valueToTest, out double d) && !Double.IsNaN(d) && !Double.IsInfinity(d))
        {
            return true;
        }

        return false;
    }
    
    public static string ShowLastNumber()
    {
        return "[#" + (CurrentIndex + 1) + "] = " + storage.Numbers[CurrentIndex];
    }
}