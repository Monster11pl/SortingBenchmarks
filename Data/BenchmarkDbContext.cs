using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class BenchmarkDbContext : DbContext
{
    public DbSet<Benchmark>  Benchmarks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dataSource = Path.Combine(DatabaseHelper.GetDataProjectDataSource(), "Benchmarks.db");
        optionsBuilder.UseSqlite(dataSource);
    }
        


}