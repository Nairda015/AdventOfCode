using Y2022.CommonModels;

namespace Y2022.D09;

public class ArrayEntryPointA : IArrayEntryPoint
{
    private static readonly HashSet<Point2D> TailPositionHistory = new()
    {
        new Point2D(0, 0)
    };
    private static Point2D _currentHeadPosition = new(0, 0);
    private static Point2D _lastTailPosition = new(0, 0);

    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    public static string Solve(string[] input)
    {
        var commands = input
            .Select(x => MapToVector(x[0], int.Parse(x[2..])));
        
        foreach (var command in commands)
        {
            MakeMove(command);
        }

        return TailPositionHistory.Count.ToString();
    }

    private static void MakeMove(Vector2D moves)
    {
        var move = moves.Normalize();
        for (var i = 0; i < moves.Length; i++)
        {
            _currentHeadPosition = new Point2D(_currentHeadPosition.X + move.X, _currentHeadPosition.Y + move.Y);
            //find distance between head and tail

            var distance = Vector2D.CreateFormPoints(_currentHeadPosition, _lastTailPosition);
            MakeTailMove(distance);
        }
    }

    private static void MakeTailMove(Vector2D distance)
    {
        if (Math.Abs(distance.X) is 2)
        {
            _lastTailPosition = new Point2D(
                _lastTailPosition.X + distance.X / 2,
                _lastTailPosition.Y + distance.Y);
            TailPositionHistory.Add(_lastTailPosition);
        }
        else if (Math.Abs(distance.Y) is 2)
        {
            _lastTailPosition = new Point2D(
                _lastTailPosition.X + distance.X,
                _lastTailPosition.Y + distance.Y / 2);
            TailPositionHistory.Add(_lastTailPosition);
        }
    }

    private static Vector2D MapToVector(char direction, int length)
    {
        return direction switch
        {
            'R' => Vector2D.CreateHorizontal(length),
            'L' => Vector2D.CreateHorizontal(-length),
            'U' => Vector2D.CreateVertical(length),
            'D' => Vector2D.CreateVertical(-length),
            _ => throw new ArgumentException($"Unknown direction {direction}")
        };
    }

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D09/input.txt");
}