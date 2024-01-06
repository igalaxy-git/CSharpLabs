namespace Lab5.Models.Commands;

public interface ICommand
{
    string Key { get; }

    public void do_command();
}