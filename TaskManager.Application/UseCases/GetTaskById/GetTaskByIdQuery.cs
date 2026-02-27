using MediatR;

namespace TaskManager.Application.UseCases.GetTaskById;

public sealed record GetTaskByIdQuery(Guid Id) : IRequest<TaskDetailsDto?>;
