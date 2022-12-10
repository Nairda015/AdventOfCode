namespace Y2022.D10;

public class ArrayEntryPointB : IArrayEntryPoint
{
    private static int _sprite = 1;

    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    public static string Solve(string[] input)
    {
        var betterInput = new List<string>();

        foreach (var line in input)
        { 
            if (line.StartsWith('a')) betterInput.Add("noop");
            betterInput.Add(line);
        }

        var groups = betterInput.Chunk(40);
        foreach (var group in groups) Draw(group);

        return string.Empty;
    }

    private static void Draw(IEnumerable<string> group)
    {
        var row = new List<char>();
        var crtPosition = 0;
        foreach (var line in group)
        {
            crtPosition++;

            row.Add(IsLitPixel() ? '#' : '.');

            if (!line.StartsWith('a')) continue;
            _sprite += int.Parse(line[4..]);
        }
        
        Console.WriteLine(string.Join(string.Empty, row));

        bool IsLitPixel() => Enumerable.Range(_sprite, 3).Contains(crtPosition);
    }

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D10/input.txt");
}