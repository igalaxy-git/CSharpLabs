namespace Lab4.Commands;

public class Quit:IInitCommand
{
    public string Key => "q";
    public static void Init(IDictionary<string, ICommand> dict)
    {
        var command = new Quit();
        dict.Add(command.Key,command);
    }

    private Quit(){}
    
    public void do_command()
    {
        Environment.Exit(0);
    }
}