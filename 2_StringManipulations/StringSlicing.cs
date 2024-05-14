using System.Runtime.InteropServices.JavaScript;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace StringManipulations;

[MemoryDiagnoser(true)]
public class StringSlicing
{
    private string data = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" ;

    [Benchmark]
    public void SpanSlice()
    {
        Span<char> span = data.ToCharArray();
        for (var i = 0; i < data.Length; i++)
        {
            var slice = span.Slice(0, i);
        }
    }

    [Benchmark]
    public void Substring()
    {
        for (var i = 0; i < data.Length; i++)
        {
            var substring = data.Substring(0, i);
        }
    }

    [Benchmark]
    public void ReadOnlySpanSlice()
    {
        ReadOnlySpan<char> span = data.AsSpan();
        for (int i = 0; i < data.Length; i++)
        {
            ReadOnlySpan<char> slice = span.Slice(0, i);
        }
    }

    [Benchmark]
    public void StringTakeLinq()
    {
        for (int i = 0; i < data.Length; i++)
        {
            var substring = new string(data.Take(i).ToArray());
        }
    }

    [Benchmark]
    public void MemorySlice()
    {
        var memory = data.AsMemory();
        for (int i = 0; i < data.Length; i++)
        {
            var slice = memory.Slice(0, i);
        }
    }

    [Benchmark]
    public void BufferBlockCopySubstring()
    {
        char[] charArray = new char[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            Buffer.BlockCopy(data.ToCharArray(), 0, charArray, 0, i * sizeof(char));
            var substring = new string(charArray, 0, i);
        }
    }

    [Benchmark]
    public void CustomLoopSubstring()
    {
        char[] result = new char[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                result[j] = data[j];
            }
            var substring = new string(result, 0, i);
        }
    }

    [Benchmark]
    public unsafe void UnsafeSubstring()
    {
        fixed (char* p = data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                var substring = new string(p, 0, i);
            }
        }
    }

}