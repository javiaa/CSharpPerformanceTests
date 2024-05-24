using System.Xml.Schema;
using BenchmarkDotNet.Attributes;

namespace Classes;

[MemoryDiagnoser(true)]
public class ClassStructManipulationComparison

{

    private const string Username = "username";
    [Benchmark]
    public void UserDtoClassManipulation()
    {
        var user = new UserDto(Guid.NewGuid(), Username, DateTime.Now);

        ValidateUser(user);
        user = UpdateDate(user);
        PublishEvent(user);
    }

    private void ValidateUser(UserDto user)
    {
        if(user.Username != Username)
        {
            throw new Exception("Error");
        }
    }

    private UserDto UpdateDate(UserDto user)
    {
        user.CreatedDate = DateTime.Now;
        return user;
    }

    private void PublishEvent(UserDto user)
    {
        object eventToPublish = new {user.Username, user.Id};
        // Publish event
    }


    [Benchmark]
    public void UserDtoStructManipulation()
    {
        var user = new UserDtoStruct(Guid.NewGuid(), Username, DateTime.Now);

        ValidateUser(user);
        user = UpdateDate(user);
        PublishEvent(user);
    }

    private void ValidateUser(UserDtoStruct user)
    {
        if(user.Username != Username)
        {
            throw new Exception("Error");
        }
    }

    private UserDtoStruct UpdateDate(UserDtoStruct user)
    {
        user.CreatedDate = DateTime.Now;
        return user;
    }

    private void PublishEvent(UserDtoStruct user)
    {
        object eventToPublish = new {user.Username, user.Id};
        // Publish event
    }


    [Benchmark]
    public void UserDtoStructInlineManipulation()
    {
        var user = new UserDtoStruct(Guid.NewGuid(), Username, DateTime.Now);

        if(user.Username != Username)
        {
            throw new Exception("Error");
        }
        user.CreatedDate = DateTime.Now;
        object eventToPublish = new {user.Username, user.Id};
        // Publish event
    }
}