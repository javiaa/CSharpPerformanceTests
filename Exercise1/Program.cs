using BenchmarkDotNet.Running;


namespace Exercise1;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<TestBenchmark>();
    }
}