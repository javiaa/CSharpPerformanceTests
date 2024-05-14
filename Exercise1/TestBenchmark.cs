using System.Runtime.InteropServices.JavaScript;
using BenchmarkDotNet.Attributes;

namespace Exercise1;

[MemoryDiagnoser(true)]
public class TestBenchmark
{
    private int[] data;
    private List<int> dataList;
    private const int NumberOfElements = 50000; // with 100000 windows defender stops the '.sum()'
    [GlobalSetup]
    public void Setup()
    {
        data = Enumerable.Range(0, NumberOfElements).ToArray();
        dataList = data.ToList();
    }

    [Benchmark]
    public int SumArray()
    {
        return data.Sum();
    }

    [Benchmark]
    public int SumList()
    {
        return dataList.Sum();
    }

    [Benchmark]
    public int SumManual()
    {
        int sum = 0;
        for (int i = 0; i < data.Length; i++)
        {
            sum += data[i];
        }
        return sum;
    }
}



// Exceptions
// return result


//Enummerable list


// mediator vs no mediator
// sealed class
// records vs classes

// metricas y publicaciones

//