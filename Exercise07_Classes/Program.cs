using BenchmarkDotNet.Running;


namespace Classes;

public class Program
{
    public static void Main(string[] args)
    {
        // class vs records

        BenchmarkRunner.Run<ClassRecordStructComparisonSimple>();
        // BenchmarkRunner.Run<SimpleObjectMutabilityComparison>();
        // BenchmarkRunner.Run<ClassStructManipulationComparison>();
        // BenchmarkRunner.Run<ClassesStructInListsComparison>();

        // the cost of inheritance
        // BenchmarkRunner.Run<InheritanceImpactComparison>();

    }
}