using Application.Models;

namespace Application.Services.Benchmark;

public interface IBenchmarkService
{
    public Task SaveResult(BenchmarkResult result, BenchmarkHardwareInfoDto hwInfoDto, int threadsUsed = 1);
}