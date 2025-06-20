// See https://aka.ms/new-console-template for more information

using Application;
using Application.Helpers;
using Application.Services.Benchmark;
using ConsoleBenchmarks;
using ConsoleBenchmarks.Helpers;
using Data;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SortingAlgorithms;
using SortingAlgorithms.Enums;


var services = new ServiceCollection();
services.AddApplication();
services.AddData();
using var provider = services.BuildServiceProvider();

// automatyczne wstrzyknięcie zależności:
var benchmarkService = provider.GetRequiredService<IBenchmarkService>();

Console.WriteLine("Welcome to simple sorting algorithms benchmarks!");
Console.WriteLine("\nGathering info about your system...");

var hwInfo = MachineInfoHelper.GetHardwareInfo();
Console.WriteLine(hwInfo);

bool noExit;
do
{
    var sortAlgorithm = AnswerHelper.GetSortAlgorithmPick();
    var sortElementCount = AnswerHelper.GetElementsToSortCountPick();
    var arrayToSort = ArrayGenerator.CreateAndPopulateArray(sortElementCount);
    
    var benchmarkSort = new BenchmarkSort();
    var result = benchmarkSort.Sort(arrayToSort, sortAlgorithm);
    Console.WriteLine(result);
    
    var wishToSaveResult = AnswerHelper.GetAnswerTo_WishToSaveBenchmarkToDatabase();
    if (wishToSaveResult)
    {
        try
        {
            await benchmarkService.SaveResult(result, hwInfo);
            Console.WriteLine("Benchmark result saved successfully");
        }
        catch (Exception)
        {
            Console.WriteLine("There was problem with saving benchmark data to DB");
            //log problem
        }
    }
    
    noExit = AnswerHelper.GetAnswerTo_DoAnotherBenchmark();
} 
while (noExit);

