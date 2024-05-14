using BenchmarkDotNet.Attributes;

namespace ListsAndLoops;

[MemoryDiagnoser(true)]
public class ContainsFindComparison
{

    private List<UserDto> _users = new ();
    private const int NumberOfElements = 10000;
    private const string UsernameToFind = "testusername";

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < NumberOfElements; i++)
        {
            _users.Add(new UserDto());
        }

        _users.ElementAt(NumberOfElements - 10).Username = UsernameToFind;
    }



    [Benchmark]
    public void AnyLinq()
    {
        var exists = _users.Any(u => u.Username == UsernameToFind);
        if (!exists) throw new Exception("LinqAny went wrong");
    }

    [Benchmark]
    public void ExistsLinq()
    {
        var exists = _users.Exists(u => u.Username == UsernameToFind);
        if (!exists) throw new Exception("ExistsAny went wrong");
    }

    [Benchmark]
    public void CountLinq()
    {
        var exists = _users.Count(u => u.Username == UsernameToFind) > 0;
        if (!exists) throw new Exception("CountLinq went wrong");
    }

    [Benchmark]
    public void FirstLinq()
    {
        var user = _users.First(u => u.Username == UsernameToFind);
    }


    // [Benchmark]
    // public void zz_FirstOrDefaultLinq()
    // {
    //     var user = _users.FirstOrDefault(u => u.Username == UsernameToFind);
    //     if (user == default) throw new Exception("LinqAny went wrong");
    // }
}