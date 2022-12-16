using Y2022.CommonModels;

namespace Y2022.D15;

internal class Sensor
{
    public PointXZ Position { get; }
    public PointXZ ClosestBeacon { get; }
    public int ManhattanDistance { get; }

    public Sensor(PointXZ position, PointXZ closestBeacon)
    {
        Position = position;
        ClosestBeacon = closestBeacon;
        ManhattanDistance = Math.Abs(Position.X - ClosestBeacon.X) + Math.Abs(Position.Z - ClosestBeacon.Z);
    }

    public bool IsInRange(PointXZ point)
    {
        var distance = Math.Abs(Position.X - point.X) + Math.Abs(Position.Z - point.Z);
        return distance <= ManhattanDistance;
    }
}