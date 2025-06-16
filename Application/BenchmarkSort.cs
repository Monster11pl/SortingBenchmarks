using System.Diagnostics;
using SortingAlgorithms;
using SortingAlgorithms.Algorithms;
using SortingAlgorithms.Enums;

namespace Application;

public class BenchmarkSort
{
    private readonly SortContext _sortContext = new();
    private readonly Stopwatch  _stopwatch = new();

    public BenchmarkResult Sort(int[] array, SortAlgorithm sortingAlgorithm)
    {
        //Set strategy
        switch (sortingAlgorithm)
        {
            case SortAlgorithm.BubbleSort:
                _sortContext.SetStrategy(new BubbleSort());
                break;
            
            case SortAlgorithm.QuickSort:
                _sortContext.SetStrategy(new QuickSort());
                break;
            
            default:
                throw new NotImplementedException($"Sorting algorithm not implemented: <<{sortingAlgorithm}>>");
        }
        
        //Execute strategy and benchmark time
        _stopwatch.Start();
        _sortContext.Sort(array);
        _stopwatch.Stop();

        var benchResult = new BenchmarkResult()
        {
            SortType = sortingAlgorithm,
            Time = _stopwatch.Elapsed,
            ElementsCount = array.Length
        };

        return benchResult;

    }
    
    
}