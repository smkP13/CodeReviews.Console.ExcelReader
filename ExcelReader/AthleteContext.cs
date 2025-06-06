using Microsoft.EntityFrameworkCore;
using static ExcelReader.Models;

namespace ExcelReader;

class AthleteContext : DbContext
{
    internal DbSet<Athlete> Athletes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? appFolderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        int pathLength = appFolderPath.Length - 16;
        string dbFolderPath = appFolderPath.Substring(0, pathLength);
        optionsBuilder.UseSqlite($"Data Source={dbFolderPath}/Athletes.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Athlete>().HasKey(x => new { x.Id });
        List<Athlete> Athletes = ExcelController.GetAllAthletes();
        modelBuilder.Entity<Athlete>().HasData(Athletes);
    }
}
