using BenchmarkDotNet.Running;

namespace Exercise15_Mediatr;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<ServiceDiVsMediatrBenchmark>();
    }
}