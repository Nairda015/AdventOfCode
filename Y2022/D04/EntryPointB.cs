namespace Y2022.D04;

public class EntryPointB : IEntryPoint
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
        var count = 0;
        var sections = input.Select(pair => pair.Split(",", 2));
        foreach (var pair in sections)
        {
            var section = new SectionRange(pair[0]);
            var range = new SectionRange(pair[1]).GetRange();
            if (range.Any(x => section.Contains(x))) count++;
        }

        return count.ToString();
    }

    public static string[] ReadFile() => 
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D04/input.txt");
}