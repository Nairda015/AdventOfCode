namespace Y2022;

public interface IEntryPoint
{
    static abstract void Run();
    static abstract string Calculate(string[] input);
    static abstract string[] ReadFile();
}