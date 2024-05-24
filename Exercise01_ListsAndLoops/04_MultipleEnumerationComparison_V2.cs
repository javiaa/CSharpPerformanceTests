using BenchmarkDotNet.Attributes;

namespace ListsAndLoops;

[MemoryDiagnoser(true)]
public class MultipleEnumerationComparison_V2
{

    private List<UserDto> _users = new ();
    private const int NumberOfElements = 100000;
    private const string UsernameBase = "username_";

    [GlobalSetup]
    public void Setup()
    {
        var date = DateTime.Now;
        for (var i = 0; i < NumberOfElements; i++)
        {
            _users.Add(new UserDto(Guid.NewGuid(), $"{UsernameBase}{i.ToString()}", date));
        }
    }


    [Benchmark]
    public void CountConvertToListInterChecks()
    {
        var everyUser = _users.Where(u => u.Username.StartsWith(UsernameBase)).ToList();
        var a = everyUser.Count(u => u.Username == "aaaaa" && u.CreatedDate < DateTime.Now);

        var usersEndsWith0 = everyUser.Where(u => u.Username.EndsWith("0")).ToList();
        var b = usersEndsWith0.Count(u => u.Username == "aaaaa" && u.CreatedDate < DateTime.Now);

        var usersContains100 = usersEndsWith0.Where(u => u.Username.Contains("1000")).ToList();
        var c = usersContains100.Count(u => u.Username == "aaaaa" && u.CreatedDate < DateTime.Now);
    }

    [Benchmark]
    public void CountConvertToListCheckAtTheEnd()
    {
        var everyUser = _users.Where(u => u.Username.StartsWith(UsernameBase)).ToList();
        var usersEndsWith0 = everyUser.Where(u => u.Username.EndsWith("0")).ToList();
        var usersContains100 = usersEndsWith0.Where(u => u.Username.Contains("1000")).ToList();
        var c = usersContains100.Count(u => u.Username == "aaaaa" && u.CreatedDate < DateTime.Now);
    }

    [Benchmark]
    public void CountWithEnumerableInterChecks()
    {
        var everyUser = _users.Where(u => u.Username.StartsWith(UsernameBase));
        var a = everyUser.Count(u => u.Username == "aaaaa" && u.CreatedDate < DateTime.Now);

        var usersEndsWith0 = everyUser.Where(u => u.Username.EndsWith("0"));
        var b = usersEndsWith0.Count(u => u.Username == "aaaaa" && u.CreatedDate < DateTime.Now);

        var usersContains100 = usersEndsWith0.Where(u => u.Username.Contains("1000"));
        var c = usersContains100.Count(u => u.Username == "aaaaa" && u.CreatedDate < DateTime.Now);
    }

    [Benchmark]
    public void CountWithEnumerableCheckAtTheEnd()
    {
        var everyUser = _users.Where(u => u.Username.StartsWith(UsernameBase));
        var usersEndsWith0 = everyUser.Where(u => u.Username.EndsWith("0"));
        var usersContains100 = usersEndsWith0.Where(u => u.Username.Contains("1000"));
        var c = usersContains100.Count(u => u.Username == "aaaaa" && u.CreatedDate < DateTime.Now);
    }

}