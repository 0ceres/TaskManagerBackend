using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.UseCases.UpdateTask
{
    internal sealed class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (task is null)
                return false;

            // Use the entity's method to update details since properties have private setters
            task.UpdateDetails(request.Data.Title, request.Data.Description, request.Data.DueDate);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
