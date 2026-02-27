namespace TaskManager.Application.UseCases.UpdateTask;

public sealed class UpdateTaskRequestDto
{
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime? DueDate { get; init; }
}
