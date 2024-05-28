using System.Text;
using BenchmarkDotNet.Attributes;

namespace StringManipulations;

[MemoryDiagnoser(true)]
public class SimpleStringConcatenations
{
    private const string FirstName = "John";
    private const string LastName = "Doe";
    private const string Title = "Mr.";

    [Benchmark]
    public void ConcatenateWithPlus()
    {
        var result = Title + " " + FirstName + " " + LastName;
    }

    [Benchmark]
    public void ConcatenateWithStringConcat()
    {
        var result = String.Concat(Title, " ", FirstName, " ", LastName);
    }

    [Benchmark]
    public void ConcatenateWithJoin()
    {
        var result = string.Join(" ", Title, FirstName, LastName);
    }

    [Benchmark]
    public void ConcatenateWithStringBuilder()
    {
        var sb = new StringBuilder();
        sb.Append(Title);
        sb.Append(" ");
        sb.Append(FirstName);
        sb.Append(" ");
        sb.Append(LastName);
        var result = sb.ToString();
    }

    [Benchmark]
    public void ConcatenateWithStringInterpolation()
    {
        var result = $"{Title} {FirstName} {LastName}";
    }

    [Benchmark]
    public void ConcatenateWithStringFormat()
    {
        var result = string.Format("{0} {1} {2}", Title, FirstName, LastName);
    }
}