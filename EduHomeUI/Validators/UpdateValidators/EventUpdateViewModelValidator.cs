using FluentValidation;

public class EventUpdateViewModelValidator : AbstractValidator<EventUpdateViewModel>
{
    public EventUpdateViewModelValidator()
    {
        RuleFor(vm => vm.Title)
            .NotEmpty().WithMessage("Title is required.");

        RuleFor(vm => vm.ImagePath)
            .NotEmpty().WithMessage("ImagePath is required.");

        RuleFor(vm => vm.ImageName)
            .NotEmpty().WithMessage("ImageName is required.");

        RuleFor(vm => vm.Venue)
            .NotEmpty().WithMessage("Venue is required.");

        RuleFor(vm => vm.StartTime)
            .NotEmpty().WithMessage("StartTime is required.")
            .GreaterThan(DateTime.MinValue).WithMessage("StartTime is invalid.");

        RuleFor(vm => vm.EndTime)
            .NotEmpty().WithMessage("EndTime is required.")
            .GreaterThan(DateTime.MinValue).WithMessage("EndTime is invalid.")
            .GreaterThan(vm => vm.StartTime).WithMessage("EndTime must be greater than StartTime.");

        RuleFor(vm => vm.Date)
            .NotEmpty().WithMessage("Date is required.")
            .GreaterThan(DateTime.MinValue).WithMessage("Date is invalid.");

        RuleFor(vm => vm.Description)
            .NotEmpty().WithMessage("Description is required.");

    }
}
