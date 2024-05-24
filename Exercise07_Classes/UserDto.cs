using System;

namespace Classes;

public class UserDto
{
    public UserDto(Guid id, string username, DateTime? createdDate)
    {
        Id = id;
        Username = username;
        CreatedDate = createdDate;
    }


    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime? CreatedDate { get; set; }
}

public struct UserDtoStruct
{
    public UserDtoStruct(Guid id, string username, DateTime? createdDate)
    {
        Id = id;
        Username = username;
        CreatedDate = createdDate;
    }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime? CreatedDate { get; set; }
}


public record UserDtoRecord(Guid Id, string Username, DateTime? CreatedDate);



public readonly record struct UserDtoRecordStruct(Guid Id, string Username, DateTime? CreatedDate);



public class User2Dto
{

    public User2Dto()
    {
        Id = Guid.NewGuid();
        Username = Id.ToString().Substring(0, 10);
        CreatedDate = DateTime.Now;
    }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime? CreatedDate { get; set; }
}

public struct User2DtoStruct
{
    public User2DtoStruct()
    {
        Id = Guid.NewGuid();
        Username = Id.ToString().Substring(0, 10);
        CreatedDate = DateTime.Now;
    }
    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime? CreatedDate { get; set; }
}