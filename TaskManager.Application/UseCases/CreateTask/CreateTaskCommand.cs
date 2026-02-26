using MediatR;

namespace TaskManager.Application.UseCases.CreateTask;

public sealed record CreateTaskCommand(
    string Title,
    string? Description,
    DateTime? DueDate

) : IRequest<Guid>;