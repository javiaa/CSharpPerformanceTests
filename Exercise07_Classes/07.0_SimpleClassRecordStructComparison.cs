using BenchmarkDotNet.Attributes;

namespace Classes;

[MemoryDiagnoser(true)]
public class ClassRecordStructComparisonSimple

{


    [Benchmark]
    public void UserDtoClass()
    {
        var a = new UserDto(Guid.NewGuid(), "username", DateTime.Now);
    }


    [Benchmark]
    public void UserDtoRecord()
    {
        var a = new UserDtoRecord(Guid.NewGuid(), "username", DateTime.Now);
    }

    [Benchmark]
    public void UserDtoRecordStruct()
    {
        var a = new UserDtoRecordStruct(Guid.NewGuid(), "username", DateTime.Now);
    }

    [Benchmark]
    public void UserDtoStruct()
    {
        var a = new UserDtoStruct(Guid.NewGuid(), "username", DateTime.Now);
    }

    [Benchmark]
    public void UserDtoSealedClass()
    {
        var a = new UserSealedDto(Guid.NewGuid(), "username", DateTime.Now);
    }

    [Benchmark]
    public void UserDtoSealedRecord()
    {
        var a = new UserDtoSealedRecord(Guid.NewGuid(), "username", DateTime.Now);
    }
}