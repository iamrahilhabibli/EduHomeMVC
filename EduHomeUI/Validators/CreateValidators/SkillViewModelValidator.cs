using EduHomeUI.Areas.EHMasterPanel.ViewModels.SkillViewModels;
using FluentValidation;

namespace EduHomeUI.Validators.CreateValidators
{
    public class SkillViewModelValidator : AbstractValidator<SkillViewModel>
    {
        public SkillViewModelValidator()
        {
            RuleFor(vm => vm.Skill)
                .NotEmpty().WithMessage("Skill is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Skill can only contain letters.")
                .MaximumLength(20).WithMessage("Skill cannot exceed 20 characters.");
        }
    }
}
