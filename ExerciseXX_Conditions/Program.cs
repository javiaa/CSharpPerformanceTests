using BenchmarkDotNet.Running;


namespace Classes;

public class Program
{
    public static void Main(string[] args)
    {
         //BenchmarkRunner.Run<StringConcatenations>();
        BenchmarkRunner.Run<StringSlicing>();

        // class vs records

        // the cost of inheritance

    }
}