using BenchmarkDotNet.Running;


namespace Conditions;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<PatternMatchingComparison>();
    }
}