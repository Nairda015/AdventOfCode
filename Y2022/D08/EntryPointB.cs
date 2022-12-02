namespace Y2022.D08;

public class EntryPointB : IEntryPoint
{
    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public static string Calculate(string[] input)
    {
        return string.Empty;
    }
    
    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D08/input.txt");
}