namespace SortingAlgorithms.Algorithms;

/*
 * Time: O(n*logn) - O(n^2)
 *
 * 100k elements = ~0.01 seconds, 1 thread, Ryzen 7 3800X
 * 1kk elements = ~0.16 seconds, 1 thread, Ryzen 7 3800X
 * 10kk elements = ~2.8 seconds, 1 thread, Ryzen 7 3800X
 */
public class QuickSort : ISortStrategy
{
    public void Sort(int[] array)
    {
        QuickSortAlgorithm(array, 0, array.Length - 1);
    }

    private void QuickSortAlgorithm(int[] array, int low, int high)
    {
        if (low < high)
        {
            var pivot = Partition(array, low, high);
            QuickSortAlgorithm(array, low, pivot - 1);
            QuickSortAlgorithm(array, pivot + 1, high);
        }
    }

    private int Partition(int[] array, int low, int high)
    {
        var pivot = array[high];
        var i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
        
        (array[i+1], array[high]) = (array[high], array[i+1]);
        return i + 1;
    }
}