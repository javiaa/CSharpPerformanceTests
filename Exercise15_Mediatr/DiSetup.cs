using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise15_Mediatr;

public class DiSetup
{
    public IServiceProvider ServiceProvider { get; private set; }
    public IMediator Mediator { get; private set; }

    public DiSetup()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ICreateUserService, CreateUserService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        ServiceProvider = services.BuildServiceProvider();
        Mediator = ServiceProvider.GetRequiredService<IMediator>();
    }
}