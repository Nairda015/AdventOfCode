namespace Y2022.D10;

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
        var betterInput = new List<string>();

        foreach (var line in input)
        { 
            if (line.StartsWith('a')) betterInput.Add("noop");
            betterInput.Add(line);
        }

        var sum = 1;
        var signalStrength = new List<int>();
        var cycle = 0;
        
        foreach (var line in betterInput)
        {
            cycle++;
            if (IsSuperCycle(cycle)) signalStrength.Add(sum * cycle);
            if (!line.StartsWith('a')) continue;
            sum += int.Parse(line[4..]);
        }
        
        return signalStrength.Sum().ToString();
    }

    private static bool IsSuperCycle(int cycleNumber) => (cycleNumber - 20) % 40 is 0;

    public static string[] ReadFile() => 
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D10/input.txt");
}

