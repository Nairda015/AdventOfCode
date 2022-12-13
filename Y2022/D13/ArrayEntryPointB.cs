namespace Y2022.D13;

public class ArrayEntryPointB : IArrayEntryPoint
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
        var items = new List<Node>();
        var i = 0;

        while (i < input.Length)
        {
            var inputLine = input[i++];
            if(inputLine.Length == 0)
            {
                continue;
            }

            items.Add(NodeHelper.Parse(inputLine));
        }

        var a = new ListNode
        {
            Val = new List<Node> { new IntNode { Val = 2 } }
        };

        var b = new ListNode
        {
            Val = new List<Node> { new IntNode { Val = 6 } }
        };

        items.Add(a);
        items.Add(b);

        items.Sort(NodeHelper.Compare);
        var result = (items.IndexOf(a) + 1) * (items.IndexOf(b) + 1); 
        return result.ToString();
    }

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D13/input.txt");
}