using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class BenchmarkRepository(BenchmarkDbContext context) : IBenchmarkRepository
{
    private readonly BenchmarkDbContext _context = context;

    public async Task<List<Benchmark>> GetAllAsync() => await _context.Benchmarks.ToListAsync();

    public async Task<Benchmark> GetByIdAsync(int id)
    { 
        var benchmark = await _context.Benchmarks.FindAsync(id);
        
        if(benchmark != null)
            return benchmark;
        
        throw new Exception("Benchmark not found");
    } 

    public void Add(Benchmark benchmark) => _context.Add(benchmark);

    public async Task DeleteUpdateAsync(Benchmark benchmark)
    {
        var benchmarkToDelete = await _context.Benchmarks.FindAsync(benchmark.Id);
        
        if(benchmarkToDelete != null)
            _context.Benchmarks.Remove(benchmarkToDelete);
    }

    public Task SaveChangesAsync() =>  _context.SaveChangesAsync();
}