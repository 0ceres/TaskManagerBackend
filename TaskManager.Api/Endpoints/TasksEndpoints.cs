using MediatR;
using TaskManager.Application.UseCases.GetTasks;

namespace TaskManager.Api.Endpoints;

public static class TasksEndpoints
{
    public static IEndpointRouteBuilder MapTasksEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/tasks", async (
            IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetTaskQuery(), cancellationToken);
            return Results.Ok(result);
        })
        .WithName("GetTasks")
        .WithTags("Tasks");

        return app;
    }
}
