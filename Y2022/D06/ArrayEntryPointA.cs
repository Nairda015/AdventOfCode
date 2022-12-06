using System.Diagnostics;

namespace Y2022.D06;

public class ArrayEntryPointA : IStringEntryPoint
{
    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    public static string Solve(string input)
    {
        const int bufferSize = 4;
        var queue = new Queue<char>();
        var inputAsSpan = input.AsSpan();
        foreach (var c in inputAsSpan[..bufferSize])
        {
            queue.Enqueue(c);
        }

        for (var i = bufferSize; i < input.Length; i++)
        {
            if (queue.Distinct().Count() is bufferSize)
            {
                return i.ToString();
            }

            queue.Dequeue();
            queue.Enqueue(inputAsSpan[i]);
        }

        throw new UnreachableException("XD");
    }
    
    public static string ReadFile() => 
        File.ReadAllText("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D06/input.txt");
}

