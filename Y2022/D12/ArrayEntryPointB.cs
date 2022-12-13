using System.Text;
using Y2022.CommonModels;

namespace Y2022.D12;

public class ArrayEntryPointB : IArrayEntryPoint
{
    private static readonly List<Point2D> CurrentPosition = new();
    private static readonly Dictionary<Point2D, int> VisitedPlaces = new();
    private static Point2D EndPosition;
    private static ArrayMap2D<int> Map;

    private static readonly Vector2D[] Directions =
    {
        Vector2D.CreateHorizontal(1),
        Vector2D.CreateHorizontal(-1),
        Vector2D.CreateVertical(1),
        Vector2D.CreateVertical(-1)
    };

    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    public static string Solve(string[] input)
    {
        var betterInput = ParseToMap(input);
        Map = new ArrayMap2D<int> { Value = betterInput };

        while (!VisitedPlaces.ContainsKey(EndPosition))
        {
            var currentPositionCopy = CurrentPosition.ToList();
            for (var i = 0; i < currentPositionCopy.Count; i++)
            {
                var position = CurrentPosition[i];
                TryMove(position);
            }

            CurrentPosition.RemoveAll(x => currentPositionCopy.Contains(x));
        }

        return VisitedPlaces[EndPosition].ToString();
    }

    private static void TryMove(Point2D position)
    {
        var currentDistance = VisitedPlaces[position];
        var currentPositionHeight = Map.Value[position.X, position.Y];
        foreach (var direction in Directions)
        {
            if (!Map.CanMove(position, direction)) continue;
            var newPositionCoordinates = position.Move(direction);
            if (VisitedPlaces.ContainsKey(newPositionCoordinates)) continue;
            var newPosition = Map.Value[newPositionCoordinates.X, newPositionCoordinates.Y];
            if (newPosition > currentPositionHeight + 1) continue;
            CurrentPosition.Add(newPositionCoordinates);
            VisitedPlaces.Add(newPositionCoordinates, currentDistance + 1);
        }
    }

    private static void PrintVisitedPlaces()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < Map.Height; i++)
        {
            for (var j = 0; j < Map.Width; j++)
            {
                var position = new Point2D(i, j);
                if (VisitedPlaces.TryGetValue(position, out var value))
                {
                    sb.Append(value);
                }

                sb.Append(';');
            }

            Console.WriteLine(sb.ToString());
            sb.Clear();
        }
    }

    private static int[,] ParseToMap(IReadOnlyList<string> input)
    {
        var map = new int[input[0].Length, input.Count];
        for (var i = 0; i < input.Count; i++)
        {
            for (var j = 0; j < input[0].Length; j++)
            {
                var value = input[i][j];
                map[j, i] = value switch
                {
                    'S' => InitializeStart(i, j),
                    'a' => InitializeStart(i, j),
                    'E' => InitializeEnd(i, j),
                    _ => value - 'a'
                };
            }
        }

        return map;

        int InitializeStart(int i, int j)
        {
            CurrentPosition.Add(new Point2D(j, i));
            VisitedPlaces.Add(new Point2D(j, i), 0);
            return 0;
        }

        int InitializeEnd(int i, int j)
        {
            EndPosition = new Point2D(j, i);
            return 25;
        }
    }


    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D12/input.txt");
}