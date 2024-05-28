using BenchmarkDotNet.Running;


namespace StringManipulations;

public class Program
{
    public static void Main(string[] args)
    {
        // BenchmarkRunner.Run<SimpleStringConcatenations>();
        // BenchmarkRunner.Run<StringSlicing>();
        BenchmarkRunner.Run<StringSearch>();
    }
}