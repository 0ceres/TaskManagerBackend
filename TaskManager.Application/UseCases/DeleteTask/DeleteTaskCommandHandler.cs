using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.UseCases.DeleteTask;

internal sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private IApplicationDbContext _context;

    public DeleteTaskCommandHandler(IApplicationDbContext context)
    {
        _context = context; 
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task is null)
            return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
