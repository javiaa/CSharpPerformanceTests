using BenchmarkDotNet.Attributes;

namespace ListsAndLoops;

[MemoryDiagnoser(true)]
public class LoopsComparison
{

    private List<UserDto> _users = new ();
    private const int NumberOfElements = 10000;

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < NumberOfElements; i++)
        {
            _users.Add(new UserDto());
        }
    }


    [Benchmark]
    public void ForEachLoop()
    {
        foreach (var item in _users)
        {
            item.Username = "a";
        }
    }

    [Benchmark]
    public void ForEachLinq()
    {
        _users.ForEach(item => { item.Username = "b"; });
    }

    [Benchmark]
    public void ForLoop()
    {
        for (var i = 0; i < _users.Count; i++)
        {
            _users[i].Username = "c";
        }
    }

    [Benchmark]
    public void WhileLoop()
    {
        var i = 0;
        while (i < _users.Count)
        {
            _users[i].Username = "d";
            i++;
        }
    }


    // [Benchmark]
    // public void ParallelForEach()
    // {
    //     Parallel.ForEach(_users, item =>
    //     {
    //         var x = item;
    //     });
    // }

    // [Benchmark]
    // public void PlinqForEach()
    // {
    //     var result = _users.AsParallel().Select(x => x).ToList();
    // }
    //
    // public static IEnumerable<UserDto> YieldReturnElements(List<UserDto> list)
    // {
    //     foreach (var item in list)
    //     {
    //         var a = item;
    //         yield return item;
    //     }
    // }
    //
    // [Benchmark]
    // public void ForEachYield()
    // {
    //     var allItems = YieldReturnElements(_users).ToList();
    // }
    //
    // [Benchmark]
    // public void SpanLoop()
    // {
    //     Span<UserDto> span = _users.ToArray();
    //     for (var i = 0; i < span.Length; i++)
    //     {
    //         var x = span[i];
    //     }
    // }
}