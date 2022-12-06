namespace Y2022.D05;

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
        var columns = input.TakeWhile(x => x != "").ToArray();
        var stacks = ConvertColumnsToStacks(columns);

        var orders = input
            .SkipWhile(x => x != "")
            .Skip(1)
            .Select(x => x.Split(' '))
            .Select(x => new Order(x[1], x[3], x[5]));

        foreach (var order in orders)
        {
            order.MoveBoxesMultipleAtATime(stacks);
        }

        var result = stacks.Select(queue => queue.Peek());
        return string.Join(null, result);
    }

    private static List<Stack<char>> ConvertColumnsToStacks(IReadOnlyList<string> input)
    {
        var columns = input.SkipLast(1).ToArray();
        var columnCount = int.Parse(input.Last().TrimEnd().Last().ToString());
    
        var stacks = new List<Stack<char>>();
        for (var i = 0; i < columnCount; i++)
        {
            stacks.Add(new Stack<char>());
        }

        for (var i = 0; i < columnCount; i++)
        {
            var boxNames = columns.Select(x => x[i * 4 + 1]).Reverse().ToArray();
            foreach (var t in boxNames)
            {
                if (t != ' ') stacks[i].Push(t);
            }
        }

        return stacks;
    }

    
    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D05/input.txt");
}