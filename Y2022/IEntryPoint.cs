namespace Y2022;

public interface IEntryPoint
{
    static abstract void Run();
    static abstract string Solve(string[] input);
    static abstract string[] ReadFile();
}