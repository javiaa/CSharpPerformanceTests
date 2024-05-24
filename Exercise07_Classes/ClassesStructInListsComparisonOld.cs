using BenchmarkDotNet.Attributes;

namespace Classes;

[MemoryDiagnoser(true)]
public class ClassesStructInListsComparisonOld
{

    private List<User2Dto> _users = new ();
    private List<User2DtoStruct> _usersStruct = new ();
    private const int NumberOfElements = 10000;
    private const string Username1ToFind = "testusername1";
    private const string Username2ToFind = "testusername2";
    private const string Username3ToFind = "testusername3";

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < NumberOfElements; i++)
        {
            _users.Add(new User2Dto());
        }

        _users.ElementAt(NumberOfElements - 1000).Username = Username1ToFind;
        _users.ElementAt(NumberOfElements - 100).Username = Username2ToFind;
        _users.ElementAt(NumberOfElements - 10).Username = Username3ToFind;


        for (var i = 0; i < NumberOfElements; i++)
        {
            _usersStruct.Add(new User2DtoStruct());
        }

        var tempUser1 = _usersStruct[NumberOfElements - 1000];
        tempUser1.Username = Username1ToFind;
        _usersStruct[NumberOfElements - 1000] = tempUser1;

        var tempUser2 = _usersStruct[NumberOfElements - 100];
        tempUser2.Username = Username2ToFind;
        _usersStruct[NumberOfElements - 100] = tempUser2;

        var tempUser3 = _usersStruct[NumberOfElements - 10];
        tempUser3.Username = Username3ToFind;
        _usersStruct[NumberOfElements - 10] = tempUser3;

    }


    [Benchmark]
    public void LinqFirstClasses()
    {
        var user1 = _users.First(u => u.Username == Username1ToFind);
        var user2 = _users.First(u => u.Username == Username2ToFind);
        var user3 = _users.First(u => u.Username == Username3ToFind);
    }

    [Benchmark]
    public void LinqFirstStruct()
    {
        var user1 = _usersStruct.First(u => u.Username == Username1ToFind);
        var user2 = _usersStruct.First(u => u.Username == Username2ToFind);
        var user3 = _usersStruct.First(u => u.Username == Username3ToFind);
    }


    [Benchmark]
    public void LinqFirstClassesOnlyOneTime()
    {
        var user1 = _users.First(u => u.Username == Username1ToFind);
    }

    [Benchmark]
    public void ForeachClasses()
    {
        User2Dto user1 = null, user2 = null, user3 = null;
        bool foundUser1 = false, foundUser2 = false, foundUser3 = false;
        foreach (var user in _users)
        {
            if (user.Username == Username1ToFind) { user1 = user; foundUser1 = true; }
            if (user.Username == Username2ToFind) { user2 = user; foundUser2 = true; }
            if (user.Username == Username3ToFind) { user3 = user; foundUser3 = true; }
            if (foundUser1 && foundUser2 && foundUser3) break;
        }
    }

    [Benchmark]
    public void ForeachStruct()
    {
        User2DtoStruct user1 = default, user2 = default, user3 = default;
        bool foundUser1 = false, foundUser2 = false, foundUser3 = false;
        foreach (var user in _usersStruct)
        {
            if (user.Username == Username1ToFind) { user1 = user; foundUser1 = true; }
            if (user.Username == Username2ToFind) { user2 = user; foundUser2 = true; }
            if (user.Username == Username3ToFind) { user3 = user; foundUser3 = true; }
            if (foundUser1 && foundUser2 && foundUser3) break;
        }
    }


    [Benchmark]
    public void LinqExistsClass()
    {
        var a = _users.Exists(u => u.Username == Username1ToFind);
        var b = _users.Exists(u => u.Username == Username2ToFind);
        var c = _users.Exists(u => u.Username == Username3ToFind);
    }

    [Benchmark]
    public void LinqExiststStruct()
    {
        var a = _usersStruct.Exists(u => u.Username == Username1ToFind);
        var b = _usersStruct.Exists(u => u.Username == Username2ToFind);
        var c = _usersStruct.Exists(u => u.Username == Username3ToFind);
    }

    [Benchmark]
    public void ForeachExistsStruct()
    {
        bool foundUser1 = false, foundUser2 = false, foundUser3 = false;
        foreach (var user in _usersStruct)
        {
            if (user.Username == Username1ToFind) { foundUser1 = true; }
            if (user.Username == Username2ToFind) { foundUser2 = true; }
            if (user.Username == Username3ToFind) { foundUser3 = true; }
            if (foundUser1 && foundUser2 && foundUser3) break;
        }
    }
}