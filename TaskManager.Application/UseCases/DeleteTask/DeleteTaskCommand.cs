using MediatR;

namespace TaskManager.Application.UseCases.DeleteTask;

public sealed record DeleteTaskCommand(Guid Id) : IRequest<bool>;
