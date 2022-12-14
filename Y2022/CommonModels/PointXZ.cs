namespace Y2022.CommonModels;

internal readonly record struct PointXZ(int X, int Z)
{
    public PointXZ Move(VectorXZ vector) => new(X + vector.X, Z + vector.Z);
    
    //implement add operator
    public static PointXZ operator +(PointXZ p1, VectorXZ v1) => p1.Move(v1);
}