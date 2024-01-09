using Microsoft.EntityFrameworkCore;
using Lab4.Models;

namespace Lab4.Data;

public class ApiContext : DbContext
{
    public required DbSet<NumberShell> Numbers { get; set; }
    
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
        
    }
}