namespace Y2022.D07;

internal class MyFolder
{
    public MyFolder(string name)
    {
        Name = name;
    }
    public string Name { get; }
    public MyFolder? Parent { get; init; }
    public List<MyFolder> Children { get; } = new();
    public List<MyFile> Files { get; } = new();
    public int Size => Files.Sum(x => x.Size) + Children.Sum(x => x.Size);
}

internal record MyFile(string Name, int Size);