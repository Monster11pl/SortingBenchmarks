using Application.Services.Benchmark;
using SortingAlgorithms.Enums;

namespace ConsoleBenchmarks.Helpers;

public class AnswerHelper(BenchmarkService  benchmarkService)
{
    public static SortAlgorithm GetSortAlgorithmPick()
    {
        bool badDecision =  false;
            
        do
        {
            if(badDecision) Console.WriteLine("Please, pick available sorting type.\n\n");
            
            Console.WriteLine("Select algorithm:");
            Console.WriteLine($"[1] = {SortAlgorithm.BubbleSort}");
            Console.WriteLine($"[2] = {SortAlgorithm.QuickSort}");
            string? selectedAlgorithm = Console.ReadLine();

            switch (selectedAlgorithm)
            {
                case "1":
                    return SortAlgorithm.BubbleSort;
                case "2":
                    return SortAlgorithm.QuickSort;
                default:
                    badDecision = true;
                    break;
            }
            Console.Clear();
        }
        while (true);
        
    }

    public static int GetElementsToSortCountPick()
    {
        bool badDecision =  false;
            
        do
        {
            if(badDecision) Console.WriteLine("Please, provide good number - INTEGER.\n\n");
            
            Console.WriteLine("Set number of elements to sort:");
            Console.WriteLine($"{SortAlgorithm.BubbleSort} - recommended < 100 000 (~30 sec)");
            Console.WriteLine($"{SortAlgorithm.QuickSort}  - recommended < 100 000 000 (xx sec)");
            string? stringNumber = Console.ReadLine();

            var success = Int32.TryParse(stringNumber, out int numberAsInt);
            
            if(success)
                return numberAsInt;
            badDecision = true;
            Console.Clear();
        }
        while (true);
    }

    public static bool GetAnswerTo_WishToSaveBenchmarkToDatabase()
    {
        do
        {
            Console.WriteLine("Do you want to save your benchmark result to database [y/n]");
            return GetAnswer_YesOrNo();
        }
        while (true);
    }

    public static bool GetAnswerTo_DoAnotherBenchmark()
    {
        Console.WriteLine("Do you want to do another benchmark? [y/n]");
        return GetAnswer_YesOrNo();
    }

    private static bool GetAnswer_YesOrNo()
    {
        do
        {
            string? yesOrNo = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(yesOrNo) && yesOrNo.ToLower() == "y")
                return true;
            if (!string.IsNullOrWhiteSpace(yesOrNo) && yesOrNo.ToLower() == "n")
                return false;

            Console.Clear();
            Console.WriteLine("Please, provide good answer - [Y/N].\n\n");
        }
        while (true);
    }
}