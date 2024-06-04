using System.Collections.ObjectModel;
using BenchmarkDotNet.Attributes;

namespace ListsAndLoops;

[MemoryDiagnoser(true)]
public class LoopsCollectionTypesComparison
{

    private List<UserDto> _usersList = new ();
    private IEnumerable<UserDto> _usersEnumerable;
    private IReadOnlyCollection<UserDto> _readOnlyCollectionUsers;
    private IReadOnlyList<UserDto> _readOnlyListUsers;
    private UserDto[] _usersArray;
    private const int NumberOfElements = 100000;
    #region setup

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < NumberOfElements; i++)
        {
            _usersList.Add(new UserDto());
        }

        _usersEnumerable = GetUserDtoEnumerable(_usersList);
        _readOnlyCollectionUsers  = new ReadOnlyCollection<UserDto>(_usersList);
        _readOnlyListUsers  = _usersList.AsReadOnly();
        _usersArray = _usersList.ToArray();
    }
    private static IEnumerable<UserDto> GetUserDtoEnumerable(List<UserDto> users)
    {
        foreach (var user in users)
        {
            yield return user;
        }
    }

    #endregion


    [Benchmark]
    public void IterateList()
    {
        foreach (var item in _usersList)
        {
            var x = item;
        }
    }

    [Benchmark]
    public void IterateEnumerable()
    {
        foreach (var item in _usersEnumerable)
        {
            var x = item;
        }
    }

    [Benchmark]
    public void IterateReadOnlyCollection()
    {
        foreach (var item in _readOnlyCollectionUsers)
        {
            var x = item;
        }
    }

    [Benchmark]
    public void IterateArray()
    {
        foreach (var item in _usersArray)
        {
            var x = item;
        }
    }






    // Others...

    [Benchmark]
    public void IterateReadOnlyList()
    {
        foreach (var item in _readOnlyListUsers)
        {
            var x = item;
        }
    }


    [Benchmark]
    public void IterateArrayWithConversion()
    {
        var _usersArray2 = _usersList.ToArray();
        foreach (var item in _usersArray2)
        {
            var x = item;
        }
    }

}