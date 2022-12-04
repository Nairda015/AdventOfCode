namespace Y2022.D04;

internal readonly struct SectionRange
{
    private readonly int _start;
    private readonly int _end;

    public SectionRange(string range)
    {
        var split = range.Split('-');
        _start = int.Parse(split[0]);
        _end = int.Parse(split[1]);
    }
    
    private int IsInside(SectionRange bigger)
    {
        return _start <= bigger._start && _end >= bigger._end ? 1 : 0;
    }

    public static int IsOverlapping(SectionRange a, SectionRange b)
    {
        if (a._start == b._start) return 1;
        return a._start < b._start 
            ? a.IsInside(b) 
            : b.IsInside(a);
    }
    
    public bool Contains(int value) => value >= _start && value <= _end;
    
    public IEnumerable<int> GetRange() => Enumerable.Range(_start, _end - _start + 1);
}