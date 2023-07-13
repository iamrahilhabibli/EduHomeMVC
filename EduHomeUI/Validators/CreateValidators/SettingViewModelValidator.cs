using EduHomeUI.Areas.EHMasterPanel.ViewModels.SettingViewModels;
using FluentValidation;

namespace EduHomeUI.Validators.CreateValidators
{
    public class SettingViewModelValidator:AbstractValidator<SettingCreateViewModel>
    {
        public SettingViewModelValidator()
        {
            RuleFor(x => x.Key)
                .NotEmpty().WithMessage("Key is required.");

            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Value is required.");
        }
    }
}
