using BenchmarkDotNet.Running;

namespace Exercise16_ResultResponse;

public class Program
{
    public static void Main(string[] args)
    {
        // BenchmarkRunner.Run<ResultFailVsExceptionBenchmark>();
        // BenchmarkRunner.Run<ResultSuccessVsNoResultBenchmark>();
        BenchmarkRunner.Run<ResultSuccessObjectVsNoResultObjectBenchmark>();
        // BenchmarkRunner.Run<VoidResultSuccessVsVoidNoResultBenchmark>();
    }
}