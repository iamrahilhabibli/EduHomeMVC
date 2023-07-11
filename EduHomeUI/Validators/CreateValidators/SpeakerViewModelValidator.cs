using EduHomeUI.Areas.EHMasterPanel.ViewModels.SpeakerViewModels;
using FluentValidation;

namespace EduHomeUI.Validators.CreateValidators
{
    public class SpeakerViewModelValidator : AbstractValidator<SpeakerCreateViewModel>
    {
        public SpeakerViewModelValidator()
        {
            RuleFor(vm => vm.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Name should only contain letters.")
                .MaximumLength(30).WithMessage("Name cannot exceed 30 characters.");

            RuleFor(vm => vm.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Surname should only contain letters.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");

            RuleFor(vm => vm.Position)
                .NotEmpty().WithMessage("Position is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Position should only contain letters.")
                .MaximumLength(30).WithMessage("Position cannot exceed 30 characters.");

            RuleFor(vm => vm.CompanyName)
                .NotEmpty().WithMessage("CompanyName is required.")
                .MaximumLength(30).WithMessage("CompanyName cannot exceed 30 characters.");

            RuleFor(vm => vm.ImagePath)
                .NotEmpty().WithMessage("ImagePath is required.");

            RuleFor(vm => vm.ImageName)
                .NotEmpty().WithMessage("ImageName is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("ImageName should only contain letters.")
                .MaximumLength(20).WithMessage("ImageName cannot exceed 20 characters.");
        }
    }
}
