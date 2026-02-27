using MediatR;

namespace TaskManager.Application.UseCases.UpdateTask;

public sealed record UpdateTaskCommand(
    Guid Id,
    UpdateTaskRequestDto Data
) : IRequest<bool>;

