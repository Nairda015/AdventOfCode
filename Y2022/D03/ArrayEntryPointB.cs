using System.Diagnostics;

namespace Y2022.D03;

public class ArrayEntryPointB : IArrayEntryPoint
{
    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    public static string Solve(string[] input)
    {
        var groups = input.Chunk(3).ToList();
        var commonItems = groups.Select(FindCommon);
        var result = commonItems.Sum(CalculatePriority);
        return result.ToString();
    }

    private static char FindCommon(IList<string> input)
    {
        var setA = input[0].ToHashSet();
        var setB = input[1].ToHashSet();

        foreach (var item in input[2].AsSpan())
        {
            if (setA.Contains(item) && setB.Contains(item)) return item;
        }

        throw new UnreachableException("XD");
    }

    private static int CalculatePriority(char input)
    {
        if (input > 92) return input - 96;
        return input - 64 + 26;
    }
    
    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D03/input.txt");
}