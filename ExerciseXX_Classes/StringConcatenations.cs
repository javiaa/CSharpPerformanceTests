using System.Runtime.InteropServices.JavaScript;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Classes;

[MemoryDiagnoser(true)]
public class StringConcatenations
{

    private List<string> _randomStrings ;
    private const int NumberOfElements = 1000;

    [GlobalSetup]
    public void Setup()
    {
        _randomStrings = GenerateRandomStrings(NumberOfElements, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
    }

    private static List<string> GenerateRandomStrings(int count, string characters)
    {
        var random = new Random();
        var result = new List<string>();

        for (var i = 0; i < count; i++)
        {
            var charIndex = random.Next(characters.Length);
            var randomString = characters[charIndex].ToString();
            result.Add(randomString);
        }

        return result;
    }


    [Benchmark]
    public void ConcatenateWithPlus()
    {
        var result = "";
        foreach (var s in _randomStrings)
        {
            result += s;
        }
    }
    [Benchmark]
    public void ConcatenateWithStringBuilder()
    {
        var sb = new StringBuilder();
        foreach (var s in _randomStrings)
        {
            sb.Append(s);
        }
        var result = sb.ToString();
    }
    [Benchmark]
    public void ConcatenateWithStringConcat()
    {
        var result = String.Concat(_randomStrings);
    }
    [Benchmark]
    public void ConcatenateWithJoin()
    {
        var result = String.Join("", _randomStrings);
    }

}