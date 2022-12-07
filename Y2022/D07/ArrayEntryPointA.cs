using System.Diagnostics;

namespace Y2022.D07;

public class ArrayEntryPointA : IArrayEntryPoint
{
    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    public static string Solve(string[] input)
    {
        var tree = new Dictionary<string, MyFolder>
        {
            { "/", new MyFolder("/") }
        };

        var currentDir = tree["/"];
        for (var i = 0; i < input.Length; i++)
        {
            var line = input[i];
            if (line.StartsWith("$ cd "))
            {
                var nextDirName = line[5..];
                currentDir = nextDirName switch
                {
                    "/" => tree["/"],
                    ".." => currentDir.Parent ?? throw new UnreachableException("xD"),
                    _ => currentDir.Children.First(x => x.Name == nextDirName)
                };
            }
            else if (line.StartsWith("$ ls"))
            {
                var things = input.Skip(i + 1)
                    .TakeWhile(x => !x.StartsWith("$"))
                    .ToArray();

                foreach (var thing in things)
                {
                    if (thing.StartsWith("dir "))
                    {
                        var dirName = thing[4..];
                        var dir = new MyFolder(dirName)
                        {
                            Parent = currentDir
                        };
                        var path = GetPath(dir);
                        tree.TryAdd(path, dir);
                        currentDir!.Children.Add(dir);
                    }
                    else
                    {
                        var file = thing.Split(" ");
                        currentDir.Files.Add(new MyFile(file[1], int.Parse(file[0])));
                    }
                }
                
                i += things.Length;
            }
        }

        var result = tree
            .Where(x => x.Value.Size < 100_000)
            .Sum(x => x.Value.Size);

        return result.ToString();
    }
    
    private static string GetPath(MyFolder folder)
    {
        var path = new List<string>();
        while (folder.Parent is not null)
        {
            path.Add(folder.Name);
            folder = folder.Parent;
        }

        path.Reverse();
        return string.Join("/", path);
    }
    
    public static string[] ReadFile() => 
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D07/input.txt");
}

