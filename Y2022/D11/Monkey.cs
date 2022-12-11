namespace Y2022.D11;

internal class Monkey
{
    public static int LeastCommonMultiple = 0;
    
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
        item = _operation(item) % LeastCommonMultiple;
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