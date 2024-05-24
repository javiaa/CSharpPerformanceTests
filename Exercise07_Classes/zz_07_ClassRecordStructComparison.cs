using BenchmarkDotNet.Attributes;

namespace Classes;

[MemoryDiagnoser(true)]
public class ClassRecordStructComparison

{
    private const int NumberOfElements = 10000;

    [Benchmark]
    public void UserDtoClass()
    {
        var users = new List<UserDto>(NumberOfElements);
        for (var i = 0; i < NumberOfElements; i++)
        {
            users.Add(new UserDto(Guid.NewGuid(), "username_"+i, DateTime.Now));
        }

    }


    [Benchmark]
    public void UserDtoRecord()
    {
        var users = new List<UserDtoRecord>(NumberOfElements);
        for (var i = 0; i < NumberOfElements; i++)
        {
            users.Add(new UserDtoRecord(Guid.NewGuid(), "username_"+i, DateTime.Now));
        }

    }

    [Benchmark]
    public void UserDtoRecordStruct()
    {
        var users = new List<UserDtoRecordStruct>(NumberOfElements);
        for (var i = 0; i < NumberOfElements; i++)
        {
            users.Add(new UserDtoRecordStruct(Guid.NewGuid(), "username_"+i, DateTime.Now));
        }

    }

    [Benchmark]
    public void UserDtoStruct()
    {
        var users = new List<UserDtoStruct>(NumberOfElements);
        for (var i = 0; i < NumberOfElements; i++)
        {
            users.Add(new UserDtoStruct(Guid.NewGuid(), "username_"+i, DateTime.Now));
        }
    }
}