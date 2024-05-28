namespace Exercise16_ResultResponse;

public class GetUserWithExceptionService
{
    public string GetUsername(int id)
    {
        if (id == 1)
        {
            return "User1";
        }
        else if (id == 2)
        {
            return "User2";
        }
        else
        {
            throw new Exception("UserNotFound");
        }
    }

    public UserDto GetUser(int id)
    {
        if (id == 1)
        {
            return new UserDto(1, "User1", DateTime.Now);
        }
        else if (id == 2)
        {
            return new UserDto(2, "User2", DateTime.Now);
        }
        else
        {
            throw new Exception("UserNotFound");
        }
    }

    public void CreateUser(UserDto user)
    {
        if (user.Id == 1)
        {
            return;
        }
        else if (user.Id == 2)
        {
            return;
        }
        else
        {
            throw new Exception("UserAlreadyExists");
        }
    }

    // public UserDto GetUserLayer1(int id)
    // {
    //     return GetUserLayer2(id);
    // }
    //
    // public UserDto GetUserLayer2(int id)
    // {
    //     return GetUser(id);
    // }
}