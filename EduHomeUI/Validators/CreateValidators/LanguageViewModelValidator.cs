using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using FluentValidation;

namespace EduHomeUI.Validators.CreateValidators
{
    public class LanguageViewModelValidator : AbstractValidator<LanguageViewModel>
    {
        public LanguageViewModelValidator()
        {
            RuleFor(vm => vm.LanguageOption)
                .NotEmpty().WithMessage("Language option is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Language option can only contain letters.")
                .MaximumLength(50).WithMessage("Language option cannot exceed 50 characters.");
        }
    }
}
