using BenchmarkDotNet.Attributes;

namespace ListsAndLoops;

[MemoryDiagnoser(true)]
public class ToListVsEnumComparison
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
    public void ConvertToListEveryTime()
    {
        var everyUser = _users.Where(u => u.Username.StartsWith(UsernameBase)).ToList();
        var usersEndsWith0 = everyUser.Where(u => u.Username.EndsWith("0")).ToList();
        var usersContains100 = usersEndsWith0.Where(u => u.Username.Contains("100")).ToList();
        var total = usersContains100.Count;
    }

    [Benchmark]
    public void WorkWithEnumerableUntilTheEnd()
    {
        var everyUser = _users.Where(u => u.Username.StartsWith(UsernameBase));
        var usersEndsWith0 = everyUser.Where(u => u.Username.EndsWith("0"));
        var usersContains100 = usersEndsWith0.Where(u => u.Username.Contains("100"));
        var total = usersContains100.Count();
    }

}