namespace ExerciseXX_ResultResponse;

public class GetUserWithResultService
{
    public Result<string> GetUsername(int id)
    {
        if (id == 1)
        {
            return Result<string>.Success("User1");
        }
        else if (id == 2)
        {
            return Result<string>.Success("User2");
        }
        else
        {
            return Result<string>.Failure("UserNotFound");
        }
    }

    public Result<UserDto> GetUser(int id)
    {
        if (id == 1)
        {
            return Result<UserDto>.Success(new UserDto(1, "User1", DateTime.Now));
        }
        else if (id == 2)
        {
            return Result<UserDto>.Success(new UserDto(2, "User2", DateTime.Now));
        }
        else
        {
            return Result<UserDto>.Failure("UserNotFound");
        }
    }

    // public Result<UserDto> GetUserLayer1(int id)
    // {
    //     return GetUserLayer2(id);
    // }
    //
    // public Result<UserDto> GetUserLayer2(int id)
    // {
    //     return GetUser(id);
    // }


    public Result CreateUser(UserDto user)
    {
        if (user.Id == 1)
        {
            return Result.Success();
        }
        else if (user.Id == 2)
        {
            return Result.Success();
        }
        else
        {
            return Result.Failure("UserAlreadyExists");
        }
    }
}