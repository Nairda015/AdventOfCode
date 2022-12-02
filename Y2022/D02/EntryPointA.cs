namespace Y2022.D02;

public class EntryPointA : IEntryPoint
{
    // Cause .NET can run static parameterless methods without main
    public static void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public static string Calculate(string[] input)
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
            // A, X => Rock (1)
            // B, Y => Paper (2)
            // C, Z => Scissors (3)
            "A X" => 4, // Rock Rock = draw (3) + rock (1) = 4
            "A Y" => 8, // Rock Paper = win (6) + paper (2) = 8
            "A Z" => 3, // Rock Scissors = lose (0) + scissors (3) = 3
            "B X" => 1, // Paper Rock = lose (0) + rock (1) = 1
            "B Y" => 5, // Paper Paper = draw (3) + paper (2) = 5
            "B Z" => 9, // Paper Scissors = win (6) + scissors (3) = 9
            "C X" => 7, // Scissors Rock = win (6) + rock (1) = 7
            "C Y" => 2, // Scissors Paper = lose (0) + paper (2) = 2
            "C Z" => 6, // Scissors Scissors = draw (3) + scissors (3) = 6
            _ => throw new ArgumentException("Invalid input")
        };
    }

    public static string[] ReadFile() =>
        File.ReadAllLines("/Users/adrianfranczak/Repos/Private/AoC/Y2022/D02/input.txt");
}