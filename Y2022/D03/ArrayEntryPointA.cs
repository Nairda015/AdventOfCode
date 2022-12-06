using System.Diagnostics;

namespace Y2022.D03;

public class ArrayEntryPointA : IArrayEntryPoint
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
        var commonItems = input.Select(FindCommon);
        var result = commonItems.Sum(CalculatePriority);
        return result.ToString();
    }

    private static char FindCommon(string input)
    {
        var a = input.AsSpan(0, input.Length / 2);

        var set = new HashSet<char>();
        foreach (var c in input.AsSpan(input.Length / 2))
        {
            set.Add(c);
        }

        foreach (var item in a)
        {
            if (set.Contains(item)) return item;
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