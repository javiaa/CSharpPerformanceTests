namespace Exercise15_Mediatr;

public class UserDto
{
    public UserDto(int id, string username, DateTime? createdDate)
    {
        Id = id;
        Username = username;
        CreatedDate = createdDate;
    }

    public int Id { get; set; }
    public string Username { get; set; }
    public DateTime? CreatedDate { get; set; }
}