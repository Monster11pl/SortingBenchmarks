using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class BenchmarkDbContext : DbContext
{
    public DbSet<Benchmark>  Benchmarks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(GetDataProjectDirectory(), "Benchmarks.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
        
    private static string GetDataProjectDirectory()
    {
        // Zakładamy, że program uruchamiany jest z bin/... więc cofamy się do katalogu głównego solution
        var baseDir = AppContext.BaseDirectory;

        // Cofnij się z bin/Debug/netX.Y do root i wejdź do Data/
        var dataDir = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\..\Data"));

        Directory.CreateDirectory(dataDir); // Na wypadek gdyby Data/ nie istniało

        return dataDir;
    }

}