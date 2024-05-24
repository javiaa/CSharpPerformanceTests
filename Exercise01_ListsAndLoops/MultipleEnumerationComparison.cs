using BenchmarkDotNet.Attributes;

namespace ListsAndLoops;

[MemoryDiagnoser(true)]
public class MultipleEnumerationComparison
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
    public void AnyConvertToListEveryTime()
    {
        var usersContains100 = GetListOfUserFulfillingConditions();
        DoAny(usersContains100);
    }

    [Benchmark]
    public void CountConvertToListEveryTime()
    {
        var usersContains100 = GetListOfUserFulfillingConditions();
        DoCount(usersContains100);
    }

    [Benchmark]
    public void AnyWithEnumerableUntilTheEnd()
    {
        var usersContains100 = GetEnumerationOfUserFulfillingConditions();
        DoAny(usersContains100);
    }

    [Benchmark]
    public void CountWithEnumerableUntilTheEnd()
    {
        var usersContains100 = GetEnumerationOfUserFulfillingConditions();
        DoCount(usersContains100);
    }



    private List<UserDto> GetListOfUserFulfillingConditions()
    {
        var everyUser = _users.Where(u => u.Username.StartsWith(UsernameBase)).ToList();
        var usersEndsWith0 = everyUser.Where(u => u.Username.EndsWith("0")).ToList();
        return usersEndsWith0.Where(u => u.Username.Contains("1000")).ToList();
    }

    private IEnumerable<UserDto> GetEnumerationOfUserFulfillingConditions()
    {
        var everyUser = _users.Where(u => u.Username.StartsWith(UsernameBase));
        var usersEndsWith0 = everyUser.Where(u => u.Username.EndsWith("0"));
        return usersEndsWith0.Where(u => u.Username.Contains("1000"));
    }

    private static void DoAny(IEnumerable<UserDto> users)
    {
        var a = users.Any();
    }

    private static void DoCount(IEnumerable<UserDto> users)
    {
        var a = users.Any();
        if (a) { var b = users.Count(u => u.Username == "aaaaa" && u.CreatedDate < DateTime.Now); }
    }





    // [Benchmark]
    // public void ConvertToListEveryTime()
    // {
    //     var users = GetListOfUserFulfillingConditions();
    //     foreach (var item in users)
    //     {
    //         if (item.Username.Contains("1000"))
    //         {
    //             // do stuff
    //         }
    //     }
    // }
    //
    // [Benchmark]
    // public void WorkWithEnumerableUntilTheEnd()
    // {
    //     var users = GetEnumerationOfUserFulfillingConditions();
    //     foreach (var item in users)
    //     {
    //         if (item.Username.Contains("1000"))
    //         {
    //             // do stuff
    //         }
    //     }
    // }



}