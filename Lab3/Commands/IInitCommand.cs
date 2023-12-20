namespace Lab3.Commands;

public interface IInitCommand:ICommand
{
    abstract static void Init(IDictionary<string, ICommand> dict);
}