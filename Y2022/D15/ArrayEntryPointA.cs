using System.Diagnostics;
using Y2022.CommonModels;

namespace Y2022.D15;

public class ArrayEntryPointPointA : IArrayEntryPointWithSpecification
{
    private static readonly HashSet<PointXZ> Spots = new();

    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var ts = Stopwatch.GetTimestamp();
        var input = ReadFile();
        var result = Solve(input, 2_000_000);
        Console.WriteLine($"Time: {Stopwatch.GetElapsedTime(ts)}");
        Console.WriteLine(result);
    }

    public static string Solve(string[] input, int line)
    {
        var sensors = input
            .Select(x => x.Split('=', ',', ':'))
            .Select(x => new[] { x[1], x[3], x[5], x[7] }.Select(int.Parse).ToArray())
            .Select(x => new[] { new PointXZ(x[0], x[1]), new PointXZ(x[2], x[3]) })
            .Select(x => new Sensor(x[0], x[1]))
            .ToList();

        sensors.ForEach(sensor => MarkEmptySpotsOnLine(sensor, line));
        
        var sensorsInLine = sensors.Count(x => x.Position.Z == line);
        var beaconInLine = sensors
            .DistinctBy(x => x.ClosestBeacon)
            .Count(x => x.ClosestBeacon.Z == line);
        var result = Spots.Count - sensorsInLine - beaconInLine;
        return result.ToString();
    }

    private static void MarkEmptySpotsOnLine(Sensor sensor, int line)
    {
        if (!IsInRange(sensor, line)) return;

        var maxX = sensor.ManhattanDistance - Math.Abs(sensor.Position.Z - line);
        for (var i = -maxX; i <= maxX; i++)
            Spots.Add(new PointXZ(sensor.Position.X + i, line));
    }

    private static bool IsInRange(Sensor sensor, int line) =>
        Math.Abs(sensor.Position.Z - line) <= sensor.ManhattanDistance;

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D15/input.txt");
}