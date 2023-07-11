using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;
using FluentValidation;

public class AssesmentViewModelValidator : AbstractValidator<AssesmentViewModel>
{
    public AssesmentViewModelValidator()
    {
        RuleFor(vm => vm.AssesmentType)
            .NotEmpty().WithMessage("Assesment type is required")
            .Matches("^[a-zA-Z]+$").WithMessage("Assesment type can only contain letters")
            .MaximumLength(50).WithMessage("Assesment type cannot exceed 50 characters");
    }
}
