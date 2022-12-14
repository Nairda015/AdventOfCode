using Y2022.CommonModels;

namespace Y2022.D14;

public class ArrayEntryPointA : IArrayEntryPoint
{
    private static readonly HashSet<PointXZ> Rocks = new();
    private static readonly HashSet<PointXZ> Sand = new();
    private static int MaxZ; 
    private static readonly PointXZ PouringSpot = new(500, 0);
    private static readonly VectorXZ Down = new() {X = 0, Z = 1};
    private static readonly VectorXZ DownLeft = new() {X = -1, Z = 1};
    private static readonly VectorXZ DownRight = new() {X = 1, Z = 1};
    

    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    public static string Solve(string[] input)
    {
        const StringSplitOptions stringSplitOptions = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;
        var inputAsPoints = input.Select(x => x
                .Split("->", stringSplitOptions)
                .Select(x =>
                    x.Split(',', stringSplitOptions)
                        .Select(int.Parse)
                        .ToList())
                .Select(x => new PointXZ(x[0], x[1]))
                .ToList())
            .ToList();
        
        inputAsPoints.ForEach(PlaceRockLine);
        MaxZ = Rocks.Max(x => x.Z);

        PourSand();

        return Sand.Count.ToString();
    }

    private static void PourSand()
    {
        while (true)
        {
            var unit = PouringSpot;
            while (TryMove(ref unit))
            {
                if (unit.Z > MaxZ) return;
            }
            Sand.Add(unit);
        }
    }
    
    private static bool TryMove(ref PointXZ unit)
    {
        if (!IsSpotOccupied(unit.Move(Down)))
        {
            unit += Down;
            return true;
        }
        if (!IsSpotOccupied(unit.Move(DownLeft)))
        {
            unit += DownLeft;
            return true;
        }
        if (!IsSpotOccupied(unit.Move(DownRight)))
        {
            unit += DownRight;
            return true;
        }
        return false;
    }
    
    private static bool IsSpotOccupied(PointXZ point) => Rocks.Contains(point) || Sand.Contains(point);

    private static void PlaceRockLine(IReadOnlyList<PointXZ> input)
    {
        for (var i = 0; i < input.Count - 1; i++)
        {
            var direction = VectorXZ.CreateFormPoints(input[i + 1], input[i]).Normalize();

            var currentLocation = input[i];
            while (currentLocation != input[i + 1])
            {
                Rocks.Add(currentLocation);
                currentLocation += direction;
            }
            Rocks.Add(input[i + 1]);
        }
    }

    private static void Print()
    {
        var minX = Rocks.Min(x => x.X);
        var maxX = Rocks.Max(x => x.X);
        const int minZ = 0;
        var maxZ = Rocks.Max(x => x.Z);
        Console.Write("xxx  ");
        for (var i = minX; i < maxX; i++)
        {
            Console.Write(i.ToString()[^1]);
        }
        Console.WriteLine();
        Console.Write("xxx  ");
        for (var i = minX; i < maxX; i++)
        {
            Console.Write("_");
        }
        Console.WriteLine();

        for (var y = minZ; y <= maxZ; y++)
        {
            Console.Write($"{y.ToString().PadLeft(3, '0')} |");
            for (var x = minX; x <= maxX; x++)
            {
                var point = new PointXZ(x, y);
                var symbol = Rocks.Contains(point) 
                    ? '#' 
                    : Sand.Contains(point) 
                        ? 'o' 
                        : '.';
                
                Console.Write(symbol);
            }

            Console.WriteLine();
        }
    }

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D14/input.txt");
}