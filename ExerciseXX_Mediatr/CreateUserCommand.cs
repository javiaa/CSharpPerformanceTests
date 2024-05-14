using MediatR;

namespace ExerciseXX_Mediatr;

public class CreateUserCommand : IRequest<Guid>
{
    public UserDto User { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Guid.NewGuid());
    }
}