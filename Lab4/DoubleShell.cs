using System.ComponentModel.DataAnnotations;

namespace Lab4;

public class DoubleShell
{
    [Key]
    public required Double Value { get; set; }

    public override string ToString()
    {
        return Value.ToString();
    }  
}