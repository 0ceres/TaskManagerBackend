using FluentValidation;

namespace TaskManager.Application.UseCases.CreateTask;

public sealed class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator() 
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.DueDate)
            .Must(BeValidDate)
            .When(x => x.DueDate.HasValue);
    }

    private static bool BeValidDate(DateTime? date)
        => date > DateTime.UtcNow;
}