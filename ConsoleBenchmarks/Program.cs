// See https://aka.ms/new-console-template for more information

using Application;
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
bool noExit = true;
do
{
    var sortAlgorithm = AnswerHelper.GetSortAlgorithmPick();
    var sortElementCount = AnswerHelper.GetElementsToSortCountPick();
    var arrayToSort = ArrayGenerator.CreateAndPopulateArray(sortElementCount);
    
    var benchmarkSort = new BenchmarkSort();
    var result = benchmarkSort.Sort(arrayToSort, sortAlgorithm);

    try
    {
        await benchmarkService.SaveResult(result);
        Console.WriteLine("Benchmark result saved successfully");
    }
    catch (Exception)
    {
        Console.WriteLine("There was problem with saving benchmark data to DB");
    }
    finally
    {
        Console.WriteLine(result);    
    }
    
    noExit = false;
} 
while (noExit);


//
//
//
// // int[] testArray = [101, 22, 3, 54, 5, 6, 37, 8, 98];
// var testArray = ArrayGenerator.CreateAndPopulateArray(10_0_000);
//
// Console.WriteLine("Sort started...");
// var benchmarkSort = new BenchmarkSort();
// var bubbleSortBenchmark = benchmarkSort.Sort(testArray, SortAlgorithm.QuickSort);
//
// // Console.WriteLine($"Array1: {string.Join(",", testArray)}");
// // Console.WriteLine($"Array2: {string.Join(",", testArray2)}");
//
// Console.WriteLine($"Sorting with: {bubbleSortBenchmark.SortType}");
// Console.WriteLine($"Sorting time: {bubbleSortBenchmark.Time}");
// Console.WriteLine($"Elements count: {bubbleSortBenchmark.ElementsCount}");
//
// await benchmarkService.SaveResult(bubbleSortBenchmark);
//
// // Console.WriteLine($"Array: {string.Join(",", testArray)}");