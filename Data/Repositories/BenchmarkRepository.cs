using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class BenchmarkRepository(BenchmarkDbContext context) : IBenchmarkRepository
{
    public async Task<List<Benchmark>> GetAllAsync() => await context.Benchmarks.ToListAsync();

    public async Task<Benchmark> GetByIdAsync(int id)
    { 
        var benchmark = await context.Benchmarks.FindAsync(id);
        
        if(benchmark != null)
            return benchmark;
        
        throw new Exception("Benchmark not found");
    } 

    public void Add(Benchmark benchmark) => context.Add(benchmark);
    
    public async Task DeleteUpdateAsync(Benchmark benchmark)
    {
        var benchmarkToDelete = await context.Benchmarks.FindAsync(benchmark.Id);
        
        if(benchmarkToDelete != null)
            context.Benchmarks.Remove(benchmarkToDelete);
    }

    public async Task<bool> SaveChangesAsync() => await context.SaveChangesAsync() > 0;
}