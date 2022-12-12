namespace Y2022.CommonModels;

public static class PrintHelpers
{
    public static void Print(this int[][] values)
    {
        for (var i = 0; i < values.GetLength(0); i++)
        {
            for (var j = 0; j < values[0].Length; j++)
            {
                Console.Write(values[i][j] + ";");
            }

            Console.WriteLine();
        }
    }
}