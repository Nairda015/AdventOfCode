using Y2022.CommonModels;

namespace Y2022.D09;

public class ArrayEntryPointB : IArrayEntryPoint
{
    private static readonly HashSet<Point2D> TailPositionHistory = new() { new Point2D(0, 0) };
    private static readonly Point2D[] Rope = new Point2D[10];

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
            var currentHeadPosition = Rope[0];
            Rope[0] = new Point2D(currentHeadPosition.X + move.X, currentHeadPosition.Y + move.Y);

            for (var j = 1; j < Rope.Length; j++)
            {
                //find distance between segments 
                var distance = Vector2D.CreateFormPoints(Rope[j - 1], Rope[j]);
                MakeSegmentMove(ref Rope[j], distance);
                TailPositionHistory.Add(Rope[^1]);
            }
        }
    }

    private static void MakeSegmentMove(ref Point2D segment, Vector2D distance)
    {
        var shouldMoveX = Math.Abs(distance.X) is 2;
        var shouldMoveY = Math.Abs(distance.Y) is 2;
        if (shouldMoveX && shouldMoveY)
        {
            segment = new Point2D(
                segment.X + distance.X / 2,
                segment.Y + distance.Y / 2);
        }
        else if (shouldMoveX)
        {
            segment = new Point2D(
                segment.X + distance.X / 2,
                segment.Y + distance.Y);
        }
        else if (shouldMoveY)
        {
            segment = new Point2D(
                segment.X + distance.X,
                segment.Y + distance.Y / 2);
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