using System.Diagnostics;

namespace Y2022.D11;

public class ArrayEntryPointB : IArrayEntryPoint
{
    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var sw = Stopwatch.StartNew();
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
        Console.WriteLine(sw.ElapsedMilliseconds);
    }

    
    public static string Solve(string[] input)
    {
        var groups = input.Chunk(7).ToArray();
        var monkeys = groups.Select(ParseInput).ToArray();

        for (var i = 0; i < 1_000; i++)
        {
            foreach (var monkey in monkeys)
            {
                while (!monkey.IsQueueEmpty)
                {
                    var (id, item) = monkey.ThrowItem(false);
                    monkeys[id].ReceiveItem(item);
                }
            }
        }
        
        var ordered = monkeys
            .OrderByDescending(x => x.NumberOfInspections)
            .ToArray();
        var result = ordered[0].NumberOfInspections * ordered[1].NumberOfInspections;
        return result.ToString();
    }

    private static Monkey ParseInput(string[] input)
    {
        var queueItems = input[1]
            .Split(':', 2)
            .Last()
            .Split(", ")
            .Select(long.Parse);
        
        var queue = new Queue<long>(queueItems);

        var operations = input[2]
            .Split('=', 2)
            .Last()
            .Trim()
            .Split(' ');

        Func<long, long> operation;
        var sign = operations[1][0];
        if (operations[2].StartsWith('o'))
        {
            operation = sign is '+'
                ? new Func<long, long>(x => x + x)
                : new Func<long, long>(x => x * x);
        }
        else
        {
            var number = long.Parse(operations[2]);
            operation = sign is '+'
                ? new Func<long, long>(x => x + number)
                : new Func<long, long>(x => x * number);
        }

        var testAsString = input[3]
            .Trim()
            .Split(' ')
            .Last();

        var idIfTrue = int.Parse(input[4][^1].ToString());
        var idIfFalse = int.Parse(input[5][^1].ToString());

        return new Monkey(
            queue,
            operation,
            x => x % int.Parse(testAsString) is 0,
            idIfTrue,
            idIfFalse);

    }

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D11/input.txt");
}