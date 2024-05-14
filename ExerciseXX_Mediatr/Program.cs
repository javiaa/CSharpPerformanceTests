using BenchmarkDotNet.Running;

namespace ExerciseXX_Mediatr;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<ResultFailVsExceptionBenchmark>();
    }
}