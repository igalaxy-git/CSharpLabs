using System.Collections.Generic;

namespace Lab5.Models.Commands;

public class Nothing:IInitCommand
    {
    public string Key => "__nothing__";
    public static void Init(IDictionary<string, ICommand> dict)
    {
        var command = new Nothing();
        dict.Add(command.Key,command);
    }

    private Nothing(){}
    
    public void do_command(){}
}