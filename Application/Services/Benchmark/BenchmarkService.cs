using Application.Models;
using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace Application.Services.Benchmark;

public class BenchmarkService(IBenchmarkRepository benchmarkRepository, IBenchmarkHardwareInfoRepository hwInfoRepository, IMapper mapper) : IBenchmarkService
{
    public async Task SaveResult(BenchmarkResult result, BenchmarkHardwareInfoDto hwInfoDto, int threadsUsed = 1)
    {
        var benchmark = mapper.Map<Data.Entities.Benchmark>(result);
        var hwInfo = mapper.Map<BenchmarkHardwareInfo>(hwInfoDto);
        var hwInfoId = hwInfoRepository.AddIfNotExists(hwInfo);
        
        benchmark.ThreadsUsed = threadsUsed;
        benchmark.Date = DateTime.Now;
        benchmark.BenchmarkHardwareInfoId = hwInfoId;
        
        benchmarkRepository.Add(benchmark);
        
        var isSuccess = await benchmarkRepository.SaveChangesAsync();
        
        if(!isSuccess)
            throw new Exception("Something went wrong with benchmark db save");
    }


}