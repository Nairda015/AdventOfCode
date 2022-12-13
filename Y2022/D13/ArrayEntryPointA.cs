namespace Y2022.D13;

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
        var sum = 0;
        var pairs = 1;
        var i = 0;
        while (i < input.Length)
        {
            var left = NodeHelper.Parse(input[i++]);
            var right = NodeHelper.Parse(input[i++]);

            if (NodeHelper.Compare(left, right) == -1) sum += pairs;

            i++;
            pairs++;
        }

        return sum.ToString();
    }

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D13/input.txt");
}