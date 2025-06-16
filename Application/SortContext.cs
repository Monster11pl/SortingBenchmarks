using SortingAlgorithms;

namespace Application;

public class SortContext
{
    private ISortStrategy? _sortStrategy;
    
    public void SetStrategy(ISortStrategy sortStrategy) => _sortStrategy = sortStrategy;
    public void Sort(int[] array) => _sortStrategy.Sort(array);
}