using MediatR;

namespace TaskManager.Application.UseCases.GetTasks;

public sealed record GetTaskQuery() : IRequest<IReadOnlyList<TaskDto>>;