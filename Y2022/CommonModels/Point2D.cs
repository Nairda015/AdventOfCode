namespace Y2022.CommonModels;

internal readonly record struct Point2D(int X, int Y)
{
    public Point2D Move(Vector2D vector) => new(X + vector.X, Y + vector.Y);
}