using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.CreateTask;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public sealed class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskCommand command)
    {
        var taskId = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id = taskId }, taskId);
    }
}