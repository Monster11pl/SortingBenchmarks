namespace Application.Services.Benchmark;

public interface IBenchmarkService
{
    public Task SaveResult(BenchmarkResult result);
}