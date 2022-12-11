namespace Y2022.D11;

internal class Monkey
{
    private readonly Queue<long> _items;
    private readonly Func<long, long> _operation;
    private readonly Func<long, bool> _test;
    private readonly int _idIfTrue;
    private readonly int _idIfFalse;

    public Monkey(
        Queue<long> items,
        Func<long, long> operation,
        Func<long, bool> test,
        int idIfTrue,
        int idIfFalse)
    {
        _items = items;
        _operation = operation;
        _test = test;
        _idIfTrue = idIfTrue;
        _idIfFalse = idIfFalse;
    }

    public bool IsQueueEmpty => _items.Count is 0;
    public long NumberOfInspections;

    public (int id, long item) ThrowItem(bool shouldDecreaseWorryLevel)
    {
        var item = _items.Dequeue();
        item = _operation(item);
        NumberOfInspections++;
        if (shouldDecreaseWorryLevel)
        {
            item /= 3;
        }
        var target = _test(item) ? _idIfTrue : _idIfFalse;
        return (target, item);
    }
    
    public void ReceiveItem(long item)
    {
        _items.Enqueue(item);
    }
}