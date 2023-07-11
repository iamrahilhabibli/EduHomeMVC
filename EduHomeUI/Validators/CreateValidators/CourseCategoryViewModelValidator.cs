using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseCategoryViewModels;
using FluentValidation;

public class CourseCategoryViewModelValidator : AbstractValidator<CourseCategoryViewModel>
{
    public CourseCategoryViewModelValidator()
    {
        RuleFor(vm => vm.Category)
            .NotEmpty().WithMessage("Category is required")
            .Matches(@"^[a-zA-Z\s]+$").WithMessage("Category cannot contain digits or symbols");
    }
}
