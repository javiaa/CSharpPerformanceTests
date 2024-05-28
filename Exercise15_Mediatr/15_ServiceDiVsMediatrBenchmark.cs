using BenchmarkDotNet.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise15_Mediatr;

[MemoryDiagnoser(true)]
public class ServiceDiVsMediatrBenchmark
{
    private readonly ICreateUserService _service;
    private readonly IMediator _mediator;

    private UserDto user;

    [GlobalSetup]
    public void Setup()
    {
        user = new UserDto(1, "User1", DateTime.Now);
    }

    public ServiceDiVsMediatrBenchmark()
    {
        var setup = new DiSetup();
        _service = setup.ServiceProvider.GetRequiredService<ICreateUserService>();
        _mediator = setup.Mediator;
    }


    [Benchmark]
    public async Task DirectMethodCall()
    {
        await _service.CreateUser(user);
    }

    [Benchmark]
    public async Task MediatRMethodCall()
    {
        await _mediator.Send(new CreateUserCommand() { User = user});
    }
}