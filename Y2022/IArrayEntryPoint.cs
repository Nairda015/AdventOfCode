namespace Y2022;

public interface IArrayEntryPoint
{
    static abstract void Run();
    static abstract string Solve(string[] input);
    static abstract string[] ReadFile();
}

public interface IArrayEntryPointWithSpecification
{
    static abstract void Run();
    static abstract string Solve(string[] input, int line);
    static abstract string[] ReadFile();
}

public interface IStringEntryPoint
{
    static abstract void Run();
    static abstract string Solve(string input);
    static abstract string ReadFile();
}