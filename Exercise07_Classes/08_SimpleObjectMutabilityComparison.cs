using BenchmarkDotNet.Attributes;

namespace Classes;

[MemoryDiagnoser]
public class SimpleObjectMutabilityComparison
{

    private const int NumberOfElements = 10000;

    [Benchmark]
    public List<MutablePoint> StructsMutability()
    {
        var points = new List<MutablePoint>(NumberOfElements);
        for (int i = 0; i < NumberOfElements; i++)
        {
            var point = new MutablePoint(i, i);
            point.X += 1;
            point.Y += 1;
            points.Add(point);
        }
        return points;
    }

    [Benchmark]
    public List<MutablePointClass> ClassesMutability()
    {
        var points = new List<MutablePointClass>(NumberOfElements);
        for (int i = 0; i < NumberOfElements; i++)
        {
            var point = new MutablePointClass(i, i);
            point.X += 1;
            point.Y += 1;
            points.Add(point);
        }
        return points;
    }
}

public struct MutablePoint
{
    public int X { get; set; }
    public int Y { get; set; }

    public MutablePoint(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class MutablePointClass
{
    public int X { get; set; }
    public int Y { get; set; }

    public MutablePointClass(int x, int y)
    {
        X = x;
        Y = y;
    }

}