using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string? Description { get; private set; }
    public TaskManagerStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? DueDate { get; private set; }

    private TaskItem() { } // Para ORM, pero sin depender de él

    public TaskItem(string title, string? description, DateTime? dueDate)
    {
        ValidateTitle(title);

        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Status = TaskManagerStatus.Pending;
        CreatedAt = DateTime.UtcNow;
        DueDate = dueDate;
    }

    public void UpdateDetails(string title, string? description, DateTime? dueDate)
    {
        ValidateTitle(title);

        Title = title;
        Description = description;
        DueDate = dueDate;
    }

    public void Start()
    {
        if (Status != TaskManagerStatus.Pending)
            throw new InvalidOperationException("Only pending tasks can be started.");

        Status = TaskManagerStatus.InProgress;
    }

    public void Complete()
    {
        if (Status != TaskManagerStatus.InProgress)
            throw new InvalidOperationException("Only tasks in progress can be completed.");

        Status = TaskManagerStatus.Completed;
    }

    private static void ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");

        if (title.Length > 100)
            throw new ArgumentException("Title cannot exceed 100 characters.");
    }
}
