namespace Conditions;

public class UserDto
{
    public UserDto(Guid id, string username, DateTime? createdDate)
    {
        Id = id;
        Username = username;
        CreatedDate = createdDate;
    }

    public UserDto()
    {
        Id = Guid.NewGuid();
        Username = Id.ToString().Substring(0, 10);
        CreatedDate = DateTime.Now;
    }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime? CreatedDate { get; set; }
}