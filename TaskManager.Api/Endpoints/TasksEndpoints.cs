using MediatR;
using TaskManager.Application.UseCases.DeleteTask;
using TaskManager.Application.UseCases.GetTaskById;
using TaskManager.Application.UseCases.GetTasks;
using TaskManager.Application.UseCases.UpdateTask;

namespace TaskManager.Api.Endpoints;

public static class TasksEndpoints
{
    public static IEndpointRouteBuilder MapTasksEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/tasks", async (
            IMediator mediator, 
            CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetTaskQuery(), cancellationToken);
            return Results.Ok(result);
        })
        .WithName("GetTasks")
        .WithTags("Tasks");

        app.MapGet("/tasks/{id:guid}", async (
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var task = await mediator.Send(new GetTaskByIdQuery(id), cancellationToken);

            return task is null ? Results.NotFound() : Results.Ok(task);
        })
        .WithName("GetTaskById")
        .WithTags("Tasks");

        app.MapPost("/tasks/{id:guid}", async (
            Guid id,
            UpdateTaskRequestDto dto,
            IMediator mediator,
            CancellationToken cancellationToken ) =>
        {
            var updated = await mediator.Send(
                new UpdateTaskCommand(id, dto),
                cancellationToken);

            return updated ? Results.NoContent() : Results.NotFound();
        })
        .WithName("UpdateTask")
        .WithTags("Tasks");

        app.MapDelete("/tasks/{id:guid}", async (
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var deleted = await mediator.Send(
                new DeleteTaskCommand(id),
                cancellationToken);

            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteTask")
        .WithTags("Tasks");

        return app;
    }
}
