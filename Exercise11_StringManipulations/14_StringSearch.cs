using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace StringManipulations;

[MemoryDiagnoser(true)]
public class StringSearch
{
    private string _data;
    private string _searchTerm;

    [GlobalSetup]
    public void Setup()
    {
        _data = "The quick brown fox jumps over the lazy dog. ";
        _data = String.Concat(System.Linq.Enumerable.Repeat(_data, 1000));

        _searchTerm = "fox";
    }

    [Benchmark]
    public void UseIndexOf()
    {
        int index = _data.IndexOf(_searchTerm, StringComparison.Ordinal);
    }

    [Benchmark]
    public void UseContains()
    {
        bool found = _data.Contains(_searchTerm);
    }

    [Benchmark]
    public void UseRegex()
    {
        Regex regex = new Regex(Regex.Escape(_searchTerm));
        Match match = regex.Match(_data);
    }
}