using Microsoft.EntityFrameworkCore;

namespace Lab4
{
    internal class AppDbContext : DbContext
    {
        public DbSet<DoubleShell> Numbers { get; set; }

        public string DbPath { get; }

        public AppDbContext(string dbPath)
        {
            DbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}