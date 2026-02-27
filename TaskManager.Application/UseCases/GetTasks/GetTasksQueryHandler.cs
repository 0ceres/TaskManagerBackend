using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.UseCases.GetTasks;

internal sealed class GetTasksQueryHandler : IRequestHandler<GetTaskQuery, IReadOnlyList<TaskDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTasksQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<TaskDto>> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tasks
            .AsNoTracking()
            .OrderByDescending(t => t.CreatedAt)
            .Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status.ToString(),
                CreatedAt = t.CreatedAt,
                DueDate = t.DueDate
            })
            .ToListAsync(cancellationToken);
    }
}
