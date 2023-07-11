using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using FluentValidation;

public class CourseViewModelValidator : AbstractValidator<CourseViewModel>
{
    public CourseViewModelValidator()
    {
        RuleFor(vm => vm.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");

        RuleFor(vm => vm.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(vm => vm.ImagePath)
            .NotEmpty().WithMessage("ImagePath is required")
            .MaximumLength(255).WithMessage("ImagePath cannot exceed 255 characters");

        RuleFor(vm => vm.ImageName)
            .NotEmpty().WithMessage("ImageName is required")
            .MaximumLength(255).WithMessage("ImageName cannot exceed 255 characters");

        RuleFor(vm => vm.Start)
            .NotEmpty().WithMessage("Start date is required");

        RuleFor(vm => vm.Duration)
            .NotEmpty().WithMessage("Duration is required");

        RuleFor(vm => vm.ClassDuration)
            .NotEmpty().WithMessage("Class duration is required");

        RuleFor(vm => vm.CourseFee)
            .NotEmpty().WithMessage("Course fee is required")
            .Must(BeNumeric).WithMessage("Course fee must be a numeric value");
    }

    private bool BeNumeric(decimal value)
    {
        return decimal.TryParse(value.ToString(), out _);
    }
}
