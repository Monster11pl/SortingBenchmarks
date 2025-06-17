using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        var dataSource = Path.Combine(DatabaseHelper.GetDataProjectDataSource(), "Benchmarks.db");
        
        services.AddDbContext<BenchmarkDbContext>();

        services.AddScoped<IBenchmarkRepository, BenchmarkRepository>();

        return services;
    }
}