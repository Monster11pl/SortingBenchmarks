using SortingAlgorithms.Enums;

namespace SortingAlgorithms.Algorithms;

/*
    Very uneffective:
    - Time: O(n^2)
    - Memory: O(1)
    
    100k elements = ~31 seconds, 1 thread, Ryzen 7 3800X
*/
public class BubbleSort : ISortStrategy
{
    public const SortAlgorithm SortType = SortAlgorithm.BubbleSort;
    
    public void Sort(int[] array)
    {
        var lastIndex = array.Length;
        bool changed;

        do
        {
            changed = false;
            for (var i = 1; i < lastIndex; i++)
            {
                if (array[i-1] > array[i])
                {
                    //swap positions
                    (array[i-1], array[i]) = (array[i], array[i-1]);
                    changed = true;
                }

            }
            lastIndex--;
        }
        while (changed);
    }
}