namespace Exercise15_Mediatr;


public interface ICreateUserService
{
    Task<Guid> CreateUser(UserDto user);
}

public class CreateUserService: ICreateUserService
{
    public async Task<Guid> CreateUser(UserDto user)
    {
        return await Task.FromResult(Guid.NewGuid());
    }
}