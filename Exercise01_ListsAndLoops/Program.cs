using BenchmarkDotNet.Running;


namespace ListsAndLoops;

public class Program
{
    public static void Main(string[] args)
    {
        // loops
        // BenchmarkRunner.Run<LoopsComparison>();
        // BenchmarkRunner.Run<LoopsCollectionTypesComparison>();

        // contains, vs where vs Any vs First
         // BenchmarkRunner.Run<ContainsFindComparison>();

        // multiple enumerations
        // BenchmarkRunner.Run<ToListVsEnumComparison>();
        // BenchmarkRunner.Run<MultipleEnumerationComparison>();
         BenchmarkRunner.Run<MultipleEnumerationComparison_V2>();



        // sum? -- Excluded

    }
}