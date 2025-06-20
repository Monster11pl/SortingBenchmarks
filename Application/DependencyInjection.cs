using System.Reflection;
using Application.Services.Benchmark;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IBenchmarkService, BenchmarkService>();
        services.AddScoped<IBenchmarkRepository, BenchmarkRepository>();
        
        return services;
    }
}