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

        _users.ElementAt(NumberOfElements - 10).Username = UsernameToFind; //In element 9990!
    }


    // TEST 3.0

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


    // TEST 3.1

    [Benchmark]
    public void FirstLinq()
    {
        var user = _users.First(u => u.Username == UsernameToFind);
        if (user is null) throw new Exception("FirstLinq went wrong");
    }

    [Benchmark]
    public void FindLinq()
    {
        var user = _users.Find(u => u.Username == UsernameToFind);
        if (user is null) throw new Exception("FindLinq went wrong");
    }

    [Benchmark]
    public void Foreach()
    {
        UserDto? userResult = null;
        foreach (var user in _users)
        {
            if (user.Username == UsernameToFind)
            {
                userResult = user;
                break;
            }
        }
        if (userResult is null) throw new Exception("Foreach went wrong");
    }

}