namespace Y2022.D04;

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
        var count = input
            .Select(pair => pair.Split(",", 2))
            .Select(parts => SectionRange.IsOverlapping(new SectionRange(parts[0]), new SectionRange(parts[1])))
            .Sum();

        return count.ToString();
    }

    public static string[] ReadFile() => 
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D04/input.txt");
}