namespace Y2022.D08;

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
        var visibilities = new Visibility[input.Length, input[0].Length];

        var highestFromLeft = input.Select(x => int.Parse(x[0].ToString())).ToArray();
        var highestFromRight = input.Select(x => int.Parse(x[^1].ToString())).ToArray();
        var highestFromTop = input[0].Select(x => int.Parse(x.ToString())).ToArray();
        var highestFromBottom = input[^1].Select(x => int.Parse(x.ToString())).ToArray();
        
        FillEdges(visibilities);
        CheckFromLeft(input, visibilities, highestFromLeft);
        CheckFromRight(input, visibilities, highestFromRight);
        CheckFromTop(input, visibilities, highestFromTop);
        CheckFromBottom(input, visibilities, highestFromBottom);

        
        
        var result =  visibilities.LongLength - CountInvisible(visibilities);
        return result.ToString();
    }
    
    private static int CountInvisible(Visibility[,] visibilities)
    {
        var count = 0;
        for (var i = 0; i < visibilities.GetLength(0); i++)
        {
            for (var j = 0; j < visibilities.GetLength(1); j++)
            {
                if (visibilities[i, j] == Visibility.None)
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static void CheckFromLeft(
        IReadOnlyList<string> trees,
        Visibility[,] visibilities,
        IList<int> highestFromLeft)
    {
        for (var i = 1; i < trees.Count - 1; i++)
        {
            for (var j = 1; j < trees[0].Length - 1; j++)
            {
                var current = int.Parse(trees[i][j].ToString());
                if (current <= highestFromLeft[i]) continue;
                highestFromLeft[i] = current;
                SetVisibility(ref visibilities[i,j], Visibility.Left);
            }
        }
    }
    
    private static void CheckFromTop(
        IReadOnlyList<string> trees,
        Visibility[,] visibilities,
        IList<int> highestFromTop)
    {
        for (var i = 1; i < trees.Count - 1; i++)
        {
            for (var j = 1; j < trees[0].Length; j++)
            {
                var current = int.Parse(trees[i][j].ToString());
                if (current <= highestFromTop[j]) continue;
                highestFromTop[j] = current;
                SetVisibility(ref visibilities[i,j], Visibility.Up);
            }
        }
    }
    
    private static void CheckFromRight(
        IReadOnlyList<string> trees,
        Visibility[,] visibilities,
        IList<int> highestFromRight)
    {
        for (var i = trees.Count - 2; i > 0; i--)
        {
            for (var j = trees[0].Length - 2; j > 0; j--)
            {
                var current = int.Parse(trees[i][j].ToString());
                if (current <= highestFromRight[i]) continue;
                highestFromRight[i] = current;
                SetVisibility(ref visibilities[i,j], Visibility.Right);
            }
        }
    }
    
    private static void CheckFromBottom(
        IReadOnlyList<string> trees,
        Visibility[,] visibilities,
        IList<int> highestFromBottom)
    {
        for (var i = trees.Count - 2; i > 0; i--)
        {
            for (var j = trees[0].Length - 2; j > 0; j--)
            {
                var current = int.Parse(trees[i][j].ToString());
                if (current <= highestFromBottom[j]) continue;
                highestFromBottom[j] = current;
                SetVisibility(ref visibilities[i,j], Visibility.Down);
            }
        }
    }

    private static void FillEdges(Visibility[,] visibilities)
    {
        for (var i = 0; i < visibilities.GetLength(0); i++)
        {
            SetVisibility(ref visibilities[i, 0], Visibility.Left);
            SetVisibility(ref visibilities[i, visibilities.GetLength(1) - 1], Visibility.Right);
        }

        for (var i = 0; i < visibilities.GetLength(1); i++)
        {
            SetVisibility(ref visibilities[0, i], Visibility.Up);
            SetVisibility(ref visibilities[visibilities.GetLength(0) - 1, i], Visibility.Down);
        }
    }
    
    private static void PrintVisibilities(Visibility[,] visibilities)
    {
        for (var i = 0; i < visibilities.GetLength(0); i++)
        {
            for (var j = 0; j < visibilities.GetLength(1); j++)
            {
                Console.Write((int)visibilities[i, j] + ";");
            }

            Console.WriteLine();
        }
    }
    
    private static void SetVisibility(ref Visibility current, Visibility newDirection) 
        => current |= newDirection;

    public static string[] ReadFile() => 
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D08/input.txt");
}

[Flags]
internal enum Visibility
{
    None = 0,
    Right = 1 << 0,
    Left = 1 << 1,
    Up = 1 << 2,
    Down = 1 << 3,
}