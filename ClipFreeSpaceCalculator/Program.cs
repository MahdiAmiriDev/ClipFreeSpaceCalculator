using ClipFreeSpaceCalculator;
using System.Text.Json;



var filePath = "D:\\ClipSize\\size.json";

if (!File.Exists(filePath))
{
    Console.WriteLine("Size file not exists !!!!");
    TimeSpan.FromSeconds(4);
    Environment.Exit(0);
}

var sizeFileString = File.ReadAllText(filePath);

var sizeModel = JsonSerializer.Deserialize<ClipFreeSpaceCalculatorModel>(sizeFileString);



// Calculate the actual target sum
var targetSum = sizeModel.TotalSpace - sizeModel.NeededSpace;

// Find combinations
var results = new List<List<double>>();
FindCombinations(sizeModel.ZirkariSizeList, targetSum, new List<double>(), results, 0);

// Output the results
Console.WriteLine($"Combinations that sum to {targetSum}:");



foreach (var combination in results)
{
    Console.WriteLine($"({string.Join(" + ", combination)})");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
Environment.Exit(0);

void FindCombinations(List<double> numbers, double targetSum, List<double> currentCombination, List<List<double>> results, int startIndex)
{
    if (targetSum == 0)
    {
        // Found a valid combination
        results.Add(new List<double>(currentCombination));
        return;
    }

    for (int i = startIndex; i < numbers.Count; i++)
    {
        if (numbers[i] <= targetSum)
        {
            // Include the number in the current combination
            currentCombination.Add(numbers[i]);

            // Recur with the updated target sum and current combination
            FindCombinations(numbers, targetSum - numbers[i], currentCombination, results, i + 1);

            // Backtrack
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }
}



