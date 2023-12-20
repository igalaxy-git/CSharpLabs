using System.ComponentModel.DataAnnotations;

namespace Lab3;

public class DoubleShell
{
    [Key]
    public required Double Value { get; set; }

    public override string ToString()
    {
        return Value.ToString();
    }  
}