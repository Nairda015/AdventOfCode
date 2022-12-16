using System.Diagnostics;
using Y2022.CommonModels;

namespace Y2022.D15;

public class ArrayEntryPointB
{
    private static int _mapSize;

    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var ts = Stopwatch.GetTimestamp();
        var input = ReadFile();
        var result = Solve(input, 4_000_000);
        Console.WriteLine($"Time: {Stopwatch.GetElapsedTime(ts)}");
        Console.WriteLine(result);
    }

    public static string Solve(string[] input, int mapSize)
    {
        _mapSize = mapSize;
        var sensors = input
            .Select(x => x.Split('=', ',', ':'))
            .Select(x => new[] { x[1], x[3], x[5], x[7] }.Select(int.Parse).ToArray())
            .Select(x => new[] { new PointXZ(x[0], x[1]), new PointXZ(x[2], x[3]) })
            .Select(x => new Sensor(x[0], x[1]))
            .ToList();

        foreach (var sensor in sensors)
        {
            foreach (var point in GetOutlineInsideRange(sensor))
            {
                if (sensors.All(x => !x.IsInRange(point)))
                {
                    return ((long)point.X * 4_000_000 + point.Z).ToString();
                }
            }
        }

        throw new UnreachableException("better luck next time");
    }

    private static IEnumerable<PointXZ> GetOutlineInsideRange(Sensor sensor)
    {
        var outlineDistance = sensor.ManhattanDistance + 1;
        for (var x = -outlineDistance; x <= outlineDistance; x++)
        {
            var z = outlineDistance - Math.Abs(x);
            var top = new PointXZ(sensor.Position.X+x, sensor.Position.Z +z);
            var bottom = new PointXZ(sensor.Position.X+x, sensor.Position.Z -z);
            if (IsInsideMap(top)) yield return top;
            if (IsInsideMap(bottom)) yield return bottom;
        }
    }

    private static bool IsInsideMap(PointXZ point) =>
        point is { X: > 0, Z: > 0 }
        && point.X < _mapSize
        && point.Z < _mapSize;

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D15/input.txt");
}