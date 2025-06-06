using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static DynamicExcelReader.Models;

namespace DynamicExcelReader;

class DynamicContext : DbContext
{
    internal DbSet<DynamicData> DynamicDatas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? appFolderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        int pathLength = appFolderPath.Length - 16;
        string dbFolderPath = appFolderPath.Substring(0, pathLength);
        optionsBuilder.UseSqlite($"Data Source={dbFolderPath}/Data.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<DynamicData>? data = DynamicExcelController.GetData();
        modelBuilder.Entity<DynamicData>().HasKey(x => new { x.Id });
        modelBuilder.Entity<DynamicData>().Property(x => x.KeyValuePairs)
        .HasConversion(
            x => JsonConvert.SerializeObject(x),
            x => JsonConvert.DeserializeObject<Dictionary<string, string>>(x));
        if(data  != null) modelBuilder.Entity<DynamicData>().HasData(data);
    }
}
