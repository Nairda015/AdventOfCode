namespace Y2022.CommonModels;

internal readonly record struct VectorXZ(int X, int Z)
{
    public static VectorXZ CreateFormPoints(PointXZ p1, PointXZ p2)
        => new(p1.X - p2.X, p1.Z - p2.Z);
    
    public VectorXZ Normalize()
    {
        if (IsHorizontal()) return new VectorXZ(X / Math.Abs(X), 0);
        if (IsVertical()) return new VectorXZ(0, Z / Math.Abs(Z));
        return new VectorXZ(X / Math.Abs(X), Z / Math.Abs(Z));
    }

    private bool IsVertical() => X is 0;

    private bool IsHorizontal() => Z is 0;
}