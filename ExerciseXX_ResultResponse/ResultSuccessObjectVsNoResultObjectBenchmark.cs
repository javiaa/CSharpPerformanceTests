using BenchmarkDotNet.Attributes;

namespace ExerciseXX_ResultResponse;

[MemoryDiagnoser(true)]
public class ResultSuccessObjectVsNoResultObjectBenchmark
{
    private readonly GetUserWithExceptionService _getUserWithExceptionService = new GetUserWithExceptionService();
    private readonly GetUserWithResultService _getUserWithResultService = new GetUserWithResultService();

    private const int NumberOfCalls = 1000;
    [Benchmark]
    public bool GetUserObjectWithException()
    {
        for (var i = 0; i < NumberOfCalls; i++)
        {
            try
            {
                _getUserWithExceptionService.GetUser(1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        return true;
    }

    [Benchmark]
    public bool GetUserObjectWithResult()
    {
        for (var i = 0; i < NumberOfCalls; i++)
        {
            var result = _getUserWithResultService.GetUser(1);
            if(!result.IsSuccess)
            {
                return false;
            }
        }

        return true;
    }
}