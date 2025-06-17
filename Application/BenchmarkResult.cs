using SortingAlgorithms.Enums;

namespace Application;

public class BenchmarkResult
{
    public SortAlgorithm SortType { get; set; }
    public TimeSpan Time { get; set; }
    
    public int ElementsCount { get; set; }

    public override string ToString()
    {
        return $"Did sort array of {ElementsCount} with {SortType} algorithm with time of: {Time}";
    }
}