using System.Diagnostics;
using Y2022.D08;

namespace Y2022.CommonModels;

internal class Map2D<T>
{
    public required T[,] Value { get; set; }
    public int Width => Value.GetLength(0);
    public int Height => Value.GetLength(1);
    public T CurrentItem => Value[CurrentPosition.X, CurrentPosition.Y];
    public (int X, int Y) CurrentPosition { get; set; } = (0, 0);


    public T Move(Vector2D direction)
    {
        var newPosition = (CurrentPosition.X + direction.X, CurrentPosition.Y + direction.Y);
        if (IsOutsideMap(newPosition)) throw new UnreachableException("Cannot move outside of map");
        CurrentPosition = newPosition;
        return CurrentItem;
    }
    
    public bool CanMove(Vector2D direction)
    {
        var newPosition = (CurrentPosition.X + direction.X, CurrentPosition.Y + direction.Y);
        return !IsOutsideMap(newPosition);
    }

    private bool IsOutsideMap((int X, int Y) position) =>
        position.X < 0
        || position.X >= Width
        || position.Y < 0
        || position.Y >= Height;
}