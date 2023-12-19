namespace Lab3.Commands;

public interface ICommand
{
    string Key { get; }

    public void do_command();
}