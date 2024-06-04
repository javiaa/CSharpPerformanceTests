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


public sealed class UserSealedDto
{
    public UserSealedDto(Guid id, string username, DateTime? createdDate)
    {
        Id = id;
        Username = username;
        CreatedDate = createdDate;
    }


    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime? CreatedDate { get; set; }
}

public sealed record UserDtoSealedRecord(Guid Id, string Username, DateTime? CreatedDate);


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





public class UserDtoBig
{
    public UserDtoBig(Guid id, string username, DateTime? createdDate)
    {
        Id = id;
        Username = username;
        CreatedDate = createdDate;
        Id2 = id;
        Username2 = username;
        CreatedDate2 = createdDate;
        Id3 = id;
        Username3 = username;
        CreatedDate3 = createdDate;
        Id4 = id;
        Username4 = username;
        CreatedDate4 = createdDate;
        Id5 = id;
        Username5 = username;
        CreatedDate5 = createdDate;
        Id6 = id;
        Username6 = username;
        CreatedDate6 = createdDate;
        Id7 = id;
        Username7 = username;
        CreatedDate7 = createdDate;
        Id8 = id;
        Username8 = username;
        CreatedDate8 = createdDate;
        Id9 = id;
        Username9 = username;
        CreatedDate9 = createdDate;
        Id10 = id;
        Username10 = username;
        CreatedDate10 = createdDate;
    }
    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Guid Id2 { get; set; }
    public string Username2 { get; set; }
    public DateTime? CreatedDate2 { get; set; }
    public Guid Id3 { get; set; }
    public string Username3 { get; set; }
    public DateTime? CreatedDate3 { get; set; }
    public Guid Id4 { get; set; }
    public string Username4 { get; set; }
    public DateTime? CreatedDate4 { get; set; }
    public Guid Id5 { get; set; }
    public string Username5 { get; set; }
    public DateTime? CreatedDate5 { get; set; }
    public Guid Id6 { get; set; }
    public string Username6 { get; set; }
    public DateTime? CreatedDate6 { get; set; }
    public Guid Id7 { get; set; }
    public string Username7 { get; set; }
    public DateTime? CreatedDate7 { get; set; }
    public Guid Id8 { get; set; }
    public string Username8 { get; set; }
    public DateTime? CreatedDate8 { get; set; }
    public Guid Id9 { get; set; }
    public string Username9 { get; set; }
    public DateTime? CreatedDate9 { get; set; }
    public Guid Id10 { get; set; }
    public string Username10 { get; set; }
    public DateTime? CreatedDate10 { get; set; }
}




public struct UserDtoBigStruct
{
    public UserDtoBigStruct(Guid id, string username, DateTime? createdDate)
    {
        Id = id;
        Username = username;
        CreatedDate = createdDate;
        Id2 = id;
        Username2 = username;
        CreatedDate2 = createdDate;
        Id3 = id;
        Username3 = username;
        CreatedDate3 = createdDate;
        Id4 = id;
        Username4 = username;
        CreatedDate4 = createdDate;
        Id5 = id;
        Username5 = username;
        CreatedDate5 = createdDate;
        Id6 = id;
        Username6 = username;
        CreatedDate6 = createdDate;
        Id7 = id;
        Username7 = username;
        CreatedDate7 = createdDate;
        Id8 = id;
        Username8 = username;
        CreatedDate8 = createdDate;
        Id9 = id;
        Username9 = username;
        CreatedDate9 = createdDate;
        Id10 = id;
        Username10 = username;
        CreatedDate10 = createdDate;
    }
    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Guid Id2 { get; set; }
    public string Username2 { get; set; }
    public DateTime? CreatedDate2 { get; set; }
    public Guid Id3 { get; set; }
    public string Username3 { get; set; }
    public DateTime? CreatedDate3 { get; set; }
    public Guid Id4 { get; set; }
    public string Username4 { get; set; }
    public DateTime? CreatedDate4 { get; set; }
    public Guid Id5 { get; set; }
    public string Username5 { get; set; }
    public DateTime? CreatedDate5 { get; set; }
    public Guid Id6 { get; set; }
    public string Username6 { get; set; }
    public DateTime? CreatedDate6 { get; set; }
    public Guid Id7 { get; set; }
    public string Username7 { get; set; }
    public DateTime? CreatedDate7 { get; set; }
    public Guid Id8 { get; set; }
    public string Username8 { get; set; }
    public DateTime? CreatedDate8 { get; set; }
    public Guid Id9 { get; set; }
    public string Username9 { get; set; }
    public DateTime? CreatedDate9 { get; set; }
    public Guid Id10 { get; set; }
    public string Username10 { get; set; }
    public DateTime? CreatedDate10 { get; set; }
}