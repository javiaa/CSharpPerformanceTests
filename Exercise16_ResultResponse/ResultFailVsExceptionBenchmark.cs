using BenchmarkDotNet.Attributes;

namespace Exercise16_ResultResponse;

[MemoryDiagnoser(true)]
public class ResultFailVsExceptionBenchmark
{
    private const string UserDoesNotExistsMessage = "User not found";
    private const string UnknownErrorMessage = "Unknown error";
    private readonly GetUserWithExceptionService _getUserWithExceptionService = new GetUserWithExceptionService();
    private readonly GetUserWithResultService _getUserWithResultService = new GetUserWithResultService();


    [Benchmark]
    public string GetUsernameWithException()
    {
        try
        {
            return _getUserWithExceptionService.GetUsername(3);
        }
        catch (Exception ex)
        {
            return ex.Message == "UserNotFound" ? UserDoesNotExistsMessage : UnknownErrorMessage;
        }
    }

    [Benchmark]
    public string GetUsernameWithResult()
    {
        var result = _getUserWithResultService.GetUsername(3);
        if(!result.IsSuccess)
        {
            return result.Error == "UserNotFound" ? UserDoesNotExistsMessage : UnknownErrorMessage;
        }
        return result.Value;
    }

    [Benchmark]
    public string GetUserWithException()
    {
        try
        {
            return _getUserWithExceptionService.GetUser(3).Username;
        }
        catch (Exception ex)
        {
            return ex.Message == "UserNotFound" ? UserDoesNotExistsMessage : UnknownErrorMessage;
        }
    }

    [Benchmark]
    public string GetUserWithResult()
    {
        var result = _getUserWithResultService.GetUser(3);
        if(!result.IsSuccess)
        {
            return result.Error == "UserNotFound" ? UserDoesNotExistsMessage : UnknownErrorMessage;
        }
        return result.Value.Username;
    }
}