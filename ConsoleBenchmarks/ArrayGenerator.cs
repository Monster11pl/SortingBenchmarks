namespace ConsoleBenchmarks;

public class ArrayGenerator
{
    public static int[] CreateAndPopulateArray(int elementsCount)
    {
        var randomizer = new Random();
        var min = 0;
        var max = 100000;
        
        var newArray = Enumerable.Range(0, elementsCount)
            .Select(_ => randomizer.Next(min,max))
            .ToArray();
        
        return newArray;
    }
}