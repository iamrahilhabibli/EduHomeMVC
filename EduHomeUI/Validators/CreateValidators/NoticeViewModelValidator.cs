using EduHomeUI.Areas.EHMasterPanel.ViewModels.NoticeViewModels.cs;
using FluentValidation;

namespace EduHomeUI.Validators.CreateValidators
{
    public class NoticeViewModelValidator:AbstractValidator<NoticeCreateViewModel>
    {
        public NoticeViewModelValidator()
        {
            RuleFor(model => model.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(255).WithMessage("Description must not exceed 255 characters.");
        }
    }
}
