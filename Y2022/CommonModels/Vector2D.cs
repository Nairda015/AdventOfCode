namespace Y2022.CommonModels;

internal readonly record struct Vector2D
{
    private bool IsHorizontal => Y is 0;

    private Vector2D(int lenght, bool isHorizontal)
    {
        if (isHorizontal) X = lenght;
        else Y = lenght;
    }
    
    private Vector2D(int x, int y) => (X, Y) = (x, y);

    public static Vector2D CreateHorizontal(int lenght) => new(lenght, true);
    public static Vector2D CreateVertical(int lenght) => new(lenght, false);
    public static Vector2D CreateFormPoints(Point2D p1, Point2D p2)
        => new(p1.X - p2.X, p1.Y - p2.Y);

    public int X { get; }
    public int Y { get; }
    
    public int Length => Math.Abs(X) + Math.Abs(Y);

    public Vector2D Normalize()
    {
        return IsHorizontal
            ? CreateHorizontal(X / Math.Abs(X))
            : CreateVertical(Y / Math.Abs(Y));
    }
}