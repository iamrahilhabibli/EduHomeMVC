using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;
using FluentValidation;

namespace EduHomeUI.Validators.CreateValidators
{
    public class TeacherViewModelValidator : AbstractValidator<TeacherCreateViewModel>
    {
        public TeacherViewModelValidator()
        {
            RuleFor(vm => vm.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Name should only contain letters.");

            RuleFor(vm => vm.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Surname should only contain letters.");

            RuleFor(vm => vm.ImagePath)
                .NotEmpty().WithMessage("ImagePath is required.");

            RuleFor(vm => vm.ImageName)
                .NotEmpty().WithMessage("ImageName is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("ImageName should only contain letters.");

            RuleFor(vm => vm.Position)
                .NotEmpty().WithMessage("Position is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Position should only contain letters.");

            RuleFor(vm => vm.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(10000).WithMessage("Description cannot exceed 10000 characters.");

            RuleFor(vm => vm.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(vm => vm.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required.")
                .Matches("^[0-9]+$").WithMessage("PhoneNumber should only contain digits.");

            RuleFor(vm => vm.SkypeAddress)
                .NotEmpty().WithMessage("SkypeAddress is required.");

            RuleFor(vm => vm.LanguageSkills)
                .InclusiveBetween(0, 100).WithMessage("LanguageSkills must be between 0 and 100.");

            RuleFor(vm => vm.TeamLeaderSkills)
                .InclusiveBetween(0, 100).WithMessage("TeamLeaderSkills must be between 0 and 100.");

            RuleFor(vm => vm.DevelopmentSkills)
                .InclusiveBetween(0, 100).WithMessage("DevelopmentSkills must be between 0 and 100.");

            RuleFor(vm => vm.Design)
                .InclusiveBetween(0, 100).WithMessage("Design must be between 0 and 100.");

            RuleFor(vm => vm.Innovation)
                .InclusiveBetween(0, 100).WithMessage("Innovation must be between 0 and 100.");

            RuleFor(vm => vm.Communication)
                .InclusiveBetween(0, 100).WithMessage("Communication must be between 0 and 100.");
        }
    }
}
