namespace Y2022.D01;

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
        var groups = new List<List<int>>();
        var rowNumber = 0;
        while (rowNumber < input.Length)
        {
            var group = input
                .Skip(rowNumber)
                .TakeWhile(x => x != string.Empty)
                .Select(int.Parse)
                .ToList();
            groups.Add(group);
            rowNumber += group.Count + 1;
        }

        var sum = groups.Select(x => x.Sum())
            .OrderDescending()
            .Take(3)
            .Sum();
        return sum.ToString();
    }
    
    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D01/input.txt");
}