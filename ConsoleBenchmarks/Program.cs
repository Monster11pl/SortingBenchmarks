// See https://aka.ms/new-console-template for more information

using Application;
using ConsoleBenchmarks;
using Data;
using Data.Repositories;
using SortingAlgorithms;
using SortingAlgorithms.Enums;

Console.WriteLine("Hello, World!");

var dbContext = new BenchmarkDbContext();
var benchmarkRepository = new BenchmarkRepository(dbContext);

var test = await benchmarkRepository.GetAllAsync();
var testCount = test.Count();

// int[] testArray = [101, 22, 3, 54, 5, 6, 37, 8, 98];
var testArray = ArrayGenerator.CreateAndPopulateArray(10_000_000);


// var testArray = ArrayGenerator.CreateAndPopulateArray(1_000_000);
// var testArray2 = (int[])testArray.Clone();

// Console.WriteLine($"Array: {string.Join(",", testArray)}");

Console.WriteLine("Sort started...");
var benchmarkSort = new BenchmarkSort();
var bubbleSortBenchmark = benchmarkSort.Sort(testArray, SortAlgorithm.QuickSort);

// Console.WriteLine($"Array1: {string.Join(",", testArray)}");
// Console.WriteLine($"Array2: {string.Join(",", testArray2)}");

Console.WriteLine($"Sorting with: {bubbleSortBenchmark.SortType}");
Console.WriteLine($"Sorting time: {bubbleSortBenchmark.Time}");
Console.WriteLine($"Elements count: {bubbleSortBenchmark.ElementsCount}");

// Console.WriteLine($"Array: {string.Join(",", testArray)}");