namespace TaskManager.Application.UseCases.GetTaskById;

public sealed class TaskDetailsDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime? DueDate { get; init; }
}
