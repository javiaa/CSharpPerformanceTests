using BenchmarkDotNet.Attributes;

namespace ExerciseXX_ResultResponse;

[MemoryDiagnoser(true)]
public class VoidResultSuccessVsVoidNoResultBenchmark
{
    private readonly GetUserWithExceptionService _getUserWithExceptionService = new GetUserWithExceptionService();
    private readonly GetUserWithResultService _getUserWithResultService = new GetUserWithResultService();

    private const int NumberOfCalls = 1000;
    private UserDto user;

    [GlobalSetup]
    public void Setup()
    {
        user = new UserDto(1, "User1", DateTime.Now);
    }

    [Benchmark]
    public bool CreateUserWithException()
    {
        for (var i = 0; i < NumberOfCalls; i++)
        {
            try
            {
                _getUserWithExceptionService.CreateUser(user);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        return true;
    }

    [Benchmark]
    public bool CreateUserWithResult()
    {
        for (var i = 0; i < NumberOfCalls; i++)
        {
            var result = _getUserWithResultService.CreateUser(user);
            if(!result.IsSuccess)
            {
                return false;
            }
        }
        return true;
    }
}