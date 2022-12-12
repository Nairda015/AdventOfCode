using Y2022.CommonModels;

namespace Y2022.D12;

public class ArrayEntryPointA : IArrayEntryPoint
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
            if (newPosition > ++currentPositionHeight) continue;
            CurrentPosition.Add(newPositionCoordinates);
            VisitedPlaces.Add(newPositionCoordinates, currentDistance + 1);
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
            return -1;
        }

        int InitializeEnd(int i, int j)
        {
            EndPosition = new Point2D(j, i);
            return 26;
        }
    }

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D12/input.txt");
}

internal class ArrayMap2D<T>
{
    public required T[,] Value { get; set; }
    public int Width => Value.GetLength(0);
    public int Height => Value.GetLength(1);

    public bool CanMove(Point2D currentPosition, Vector2D direction)
    {
        var newPosition = (currentPosition.X + direction.X, currentPosition.Y + direction.Y);
        return !IsOutsideMap(newPosition);
    }

    private bool IsOutsideMap((int X, int Y) position) =>
        position.X < 0
        || position.X >= Width
        || position.Y < 0
        || position.Y >= Height;
}