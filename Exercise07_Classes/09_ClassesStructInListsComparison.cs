using BenchmarkDotNet.Attributes;

namespace Classes;

[MemoryDiagnoser(true)]
public class ClassesStructInListsComparison
{

    private List<User2Dto> _users = new ();
    private List<User2DtoStruct> _usersStruct = new ();
    private const int NumberOfElements = 10000;
    private const string Username1ToFind = "testusername1";


    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < NumberOfElements; i++)
        {
            _users.Add(new User2Dto());
        }

        _users.ElementAt(NumberOfElements - 100).Username = Username1ToFind;

        for (var i = 0; i < NumberOfElements; i++)
        {
            _usersStruct.Add(new User2DtoStruct());
        }

        var tempUser1 = _usersStruct[NumberOfElements - 100];
        tempUser1.Username = Username1ToFind;
        _usersStruct[NumberOfElements - 100] = tempUser1;
    }


    [Benchmark]
    public void LinqFindClasses()
    {
        var user1 = _users.Find(u => u.Username == Username1ToFind);
    }

    [Benchmark]
    public void LinqFindStruct()
    {
        var user1 = _usersStruct.Find(u => u.Username == Username1ToFind);
    }

    [Benchmark]
    public void LinqFirstClasses()
    {
        var user1 = _users.First(u => u.Username == Username1ToFind);
    }

    [Benchmark]
    public void LinqFirstStruct()
    {
        var user1 = _usersStruct.First(u => u.Username == Username1ToFind);
    }

    [Benchmark]
    public void ForeachClasses()
    {
        User2Dto user1 = null;
        foreach (var user in _users)
        {
            if (user.Username == Username1ToFind) { user1 = user; break; }
        }
    }

    [Benchmark]
    public void ForeachStruct()
    {
        User2DtoStruct user1 = default;
        foreach (var user in _usersStruct)
        {
            if (user.Username == Username1ToFind) { user1 = user; break; }
        }
    }
}