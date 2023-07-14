using EduHomeUI.Areas.EHMasterPanel.ViewModels.SliderViewModels;
using FluentValidation;

namespace EduHomeUI.Validators.CreateValidators
{
    public class SliderViewModelValidator:AbstractValidator<SliderCreateViewModel>
    {
        public SliderViewModelValidator()
        {
            RuleFor(x => x.ImagePath)
               .NotEmpty().WithMessage("Image path is required.");

            RuleFor(x => x.ImageName)
                .NotEmpty().WithMessage("Image name is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(255).WithMessage("Description cannot exceed 255 characters.");
        }
    }
}
