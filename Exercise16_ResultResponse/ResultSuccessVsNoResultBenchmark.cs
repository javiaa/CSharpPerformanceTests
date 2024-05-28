using BenchmarkDotNet.Attributes;

namespace Exercise16_ResultResponse;

[MemoryDiagnoser(true)]
public class ResultSuccessVsNoResultBenchmark
{
    private readonly GetUserWithExceptionService _getUserWithExceptionService = new GetUserWithExceptionService();
    private readonly GetUserWithResultService _getUserWithResultService = new GetUserWithResultService();

    private const int NumberOfCalls = 1000;
    [Benchmark]
    public bool GetUsernameReturnsString()
    {
        for (var i = 0; i < NumberOfCalls; i++)
        {
            try
            {
                _getUserWithExceptionService.GetUsername(1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        return true;
    }

    [Benchmark]
    public bool GetUsernameReturnsResult()
    {
        for (var i = 0; i < NumberOfCalls; i++)
        {
            var result = _getUserWithResultService.GetUsername(1);
            if(!result.IsSuccess)
            {
                return false;
            }
        }
        return true;
    }
}