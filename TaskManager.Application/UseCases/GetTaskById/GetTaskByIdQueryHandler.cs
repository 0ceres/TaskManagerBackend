using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.UseCases.GetTaskById;

internal sealed class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDetailsDto?>
{
    private readonly IApplicationDbContext _context;

    public GetTaskByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TaskDetailsDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tasks
            .AsNoTracking()
            .Where(t => t.Id == request.Id)
            .Select(t => new TaskDetailsDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status.ToString(),
                CreatedAt = t.CreatedAt,
                DueDate = t.DueDate
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}
