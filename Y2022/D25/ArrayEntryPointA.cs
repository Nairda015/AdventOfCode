namespace Y2022.D25;

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
        return string.Empty;
    }

    public static string[] ReadFile() => 
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D25/input.txt");
}

