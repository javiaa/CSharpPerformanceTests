using BenchmarkDotNet.Attributes;

namespace Classes;

[MemoryDiagnoser]
public class InheritanceImpactComparison {

    [Benchmark]
    public void BaseClassMethod()
    {
        var obj = new BaseClass();
        obj.VirtualMethod();
    }

    [Benchmark]
    public void DerivedClassOverridenMethod()
    {
        var obj = new DerivedClass();
        obj.VirtualMethod();
    }

    [Benchmark]
    public void DerivedClassMethod()
    {
        var obj = new DerivedClass();
        obj.DerivedClassMethod();
    }

}

public class BaseClass
{
    public virtual void VirtualMethod()
    {
        var x = DateTime.Now;
    }

}

public class DerivedClass : BaseClass
{
    public override void VirtualMethod()
    {
        var y = DateTime.Now;
    }

    public void DerivedClassMethod()
    {
        var x = DateTime.Now;
    }
}