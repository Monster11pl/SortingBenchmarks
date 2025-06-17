using AutoMapper;
using Data.Repositories;

namespace Application.Services.Benchmark;

public class BenchmarkService(IBenchmarkRepository benchmarkRepository, IMapper mapper) : IBenchmarkService
{
    public async Task SaveResult(BenchmarkResult result)
    {
        var benchmark = mapper.Map<Data.Entities.Benchmark>(result);

        benchmark.Cpu = "TEST";
        benchmark.ThreadsUsed = 1;
        benchmark.Date = DateTime.Now;
        
        benchmarkRepository.Add(benchmark);
        var isSuccess = await benchmarkRepository.SaveChangesAsync();
        
        if(!isSuccess)
            throw new Exception("Something went wrong with benchmark db save");
    }
}