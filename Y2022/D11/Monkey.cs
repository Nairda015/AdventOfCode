namespace Y2022.D11;

internal class Monkey
{
    public static int Lcm = 0;
    
    private readonly Queue<long> _items;
    private readonly Func<long, long> _operation;
    private readonly int _idIfTrue;
    private readonly int _idIfFalse;

    public Monkey(
        Queue<long> items,
        Func<long, long> operation,
        int testValue,
        int idIfTrue,
        int idIfFalse)
    {
        _items = items;
        _operation = operation;
        TestValue = testValue;
        _idIfTrue = idIfTrue;
        _idIfFalse = idIfFalse;
    }

    public bool IsQueueEmpty => _items.Count is 0;
    public long NumberOfInspections;
    public int TestValue { get; }

    public (int id, long item) ThrowItem(bool shouldDecreaseWorryLevel)
    {
        var item = _items.Dequeue();
        item = _operation(item) % Lcm;
        NumberOfInspections++;
        if (shouldDecreaseWorryLevel)
        {
            item /= 3;
        }

        var target = item % TestValue is 0 ? _idIfTrue : _idIfFalse;
        return (target, item);
    }

    public void ReceiveItem(long item)
    {
        _items.Enqueue(item);
    }
}

internal static class MathHelpers
{
    private static int Gfc(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    public static int Lcm(int a, int b)
    {
        return a / Gfc(a, b) * b;
    }
}