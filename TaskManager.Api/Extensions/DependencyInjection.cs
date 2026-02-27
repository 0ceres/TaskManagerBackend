using FluentValidation;
using TaskManager.Application.UseCases.CreateTask;

namespace TaskManager.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(CreateTaskCommand).Assembly));

        services.AddValidatorsFromAssembly(
            typeof(CreateTaskCommandValidator).Assembly);

        return services;
    }
}