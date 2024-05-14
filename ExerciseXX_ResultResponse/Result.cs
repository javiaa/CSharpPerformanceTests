namespace ExerciseXX_ResultResponse;

public class Result<T>
{
    public T Value { get; private set; }
    public string Error { get; private set; }
    public bool IsSuccess { get; private set; }

    protected Result(T value, string error, bool isSuccess)
    {
        Value = value;
        Error = error;
        IsSuccess = isSuccess;
    }

    public static Result<T> Success(T value) => new Result<T>(value, null, true);
    public static Result<T> Failure(string error) => new Result<T>(default, error, false);
}

public class Result
{
    public bool IsSuccess { get; private set; }
    public string Error { get; private set; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, string error)
    {
        if (isSuccess && error != null)
            throw new InvalidOperationException("Successful result cannot carry an error message");
        if (!isSuccess && error == null)
            throw new InvalidOperationException("Failed result needs to carry an error message");

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, null);
    public static Result Failure(string error) => new Result(false, error);
}