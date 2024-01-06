namespace Lab5.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string? _Input;
    public string? _Output;
    
    public string Output
    {
        get
        {
            return _Output;
        }

        set
        {
            _Output = value;
        }
    }

    public string Input
    {
        get
        {
            return _Input;
        }

        set
        {
            _Input = value;
        }
    }
}