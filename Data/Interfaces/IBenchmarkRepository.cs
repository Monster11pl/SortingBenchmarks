using Data.Entities;

namespace Data.Interfaces;

public interface IBenchmarkRepository
{
    Task<List<Benchmark>> GetAllAsync();
    Task<Benchmark> GetByIdAsync(int id);
    
    void Add(Benchmark benchmark);
    Task DeleteUpdateAsync(Benchmark benchmark);
    Task<bool> SaveChangesAsync();
}