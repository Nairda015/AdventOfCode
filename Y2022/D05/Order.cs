namespace Y2022.D05;

internal readonly struct Order
{
    private readonly int _count;
    private readonly int _from;
    private readonly int _to;

    public Order(string count, string from, string to)
    {
        _count = int.Parse(count);
        _from = int.Parse(from) - 1;
        _to = int.Parse(to) - 1;
    }
    
    public void MoveBoxesOneAtATime(List<Stack<char>> stacks)
    {
        for (var i = 0; i < _count; i++)
        {
            var box = stacks[_from].Pop();
            stacks[_to].Push(box);
        }
    }
    
    public void MoveBoxesMultipleAtATime(List<Stack<char>> stacks)
    {
        var boxes = new List<char>();
        for (var i = 0; i < _count; i++)
        {
            boxes.Add(stacks[_from].Pop());
        }

        boxes.Reverse();
        foreach (var box in boxes)
        {
            stacks[_to].Push(box);
        }
    }
}