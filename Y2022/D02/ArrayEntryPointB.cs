namespace Y2022.D02;

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
        var result = input.Sum(CountScore);
        return result.ToString();
    }

    private static int CountScore(string input)
    {
        return input switch
        {
            //shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors)
            //outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won)
            //X means you need to lose
            //Y means you need to end the round in a draw
            //Z means you need to win
            // A => Rock (1)
            // B => Paper (2)
            // C => Scissors (3)
            "A X" => 3, // Rock lose => lose (0) + scissors (3) = 3
            "A Y" => 4, // Rock draw => draw (3) + rock (1) = 4
            "A Z" => 8, // Rock win => win (6) + paper (2) = 8
            "B X" => 1, // Paper lose => lose (0) + rock (1) = 1
            "B Y" => 5, // Paper draw => draw (3) + paper (2) = 5
            "B Z" => 9, // Paper win => win (6) + scissors (3) = 9
            "C X" => 2, // Scissors lose => lose (0) + paper (2) = 2
            "C Y" => 6, // Scissors draw => draw (3) + scissors (3) = 6
            "C Z" => 7, // Scissors win => win (6) + rock (1) = 7
            _ => throw new ArgumentException("Invalid input")
        };
    }
    
    public static string[] ReadFile() => 
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D02/input.txt");
}