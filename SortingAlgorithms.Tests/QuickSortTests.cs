using Application;
using FluentAssertions;
using SortingAlgorithms.Enums;

namespace SortingAlgorithms.Tests;

public class QuickSortTests
{
    [Fact]
    public void QuickSort_WithSimpleArray_ShouldReturnValidArray()
    {
        int[] simpleArray = [101, 22, 3, 54, 5, 6, 37, 8, 98];
        int[] sortedArray = [3, 5, 6, 8, 22, 37, 54, 98, 101];
        
        var benchmarkSort = new BenchmarkSort();
        benchmarkSort.Sort(simpleArray, SortAlgorithm.QuickSort);
        
        simpleArray.Should().Equal(sortedArray);
    }
}