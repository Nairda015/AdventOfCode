using Y2022.CommonModels;

namespace Y2022.D08;

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
        var map = new Map2D<int> { Value = ParseToMap(input) };
        var result = new int[map.Width, map.Height];
        var max = 0;

        for (var i = 1; i < map.Width - 1; i++)
        {
            for (var j = 1; j < map.Height - 1; j++)
            {
                var sum = 1;
                map.CurrentPosition = (i, j);
                sum *= CheckDirection(map, Vector2D.CreateHorizontal(1));
                sum *= CheckDirection(map, Vector2D.CreateHorizontal(-1));
                sum *= CheckDirection(map, Vector2D.CreateVertical(1));
                sum *= CheckDirection(map, Vector2D.CreateVertical(-1));
                result[i, j] = sum;
                if (sum > max) max = sum;
            }
        }

        return max.ToString();
    }

    private static int CheckDirection(Map2D<int> map, Vector2D direction)
    {
        var start = map.CurrentItem;
        var startingPosition = map.CurrentPosition;
        var count = 0;
        try
        {
            while (map.CanMove(direction))
            {
                count++;
                var value = map.Move(direction);
                if (value >= start) return count;
            }

            return count;
        }
        finally
        {
            map.CurrentPosition = startingPosition;
        }
    }

    private static int[,] ParseToMap(IReadOnlyList<string> input)
    {
        var map = new int[input.Count, input[0].Length];
        for (var i = 0; i < input.Count; i++)
        {
            for (var j = 0; j < input[i].Length; j++)
            {
                map[i, j] = int.Parse(input[i][j].ToString());
            }
        }
        return map;
    }
    
    private static void Print(int[,] visibilities)
    {
        for (var i = 0; i < visibilities.GetLength(0); i++)
        {
            for (var j = 0; j < visibilities.GetLength(1); j++)
            {
                Console.Write(visibilities[i, j] + ";");
            }

            Console.WriteLine();
        }
    }

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D08/input.txt");
}