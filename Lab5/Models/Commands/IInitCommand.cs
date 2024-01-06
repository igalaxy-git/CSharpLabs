using System.Collections.Generic;

namespace Lab5.Models.Commands;

public interface IInitCommand:ICommand
{
    abstract static void Init(IDictionary<string, ICommand> dict);
}