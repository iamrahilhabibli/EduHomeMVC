using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels;
using FluentValidation;
using System;

namespace EduHomeUI.Validators.CreateValidators
{
    public class EventViewModelValidator : AbstractValidator<EventCreateViewModel>
    {
        public EventViewModelValidator()
        {
            RuleFor(vm => vm.Title)
                .NotEmpty().WithMessage("Title is required.");

            RuleFor(vm => vm.ImagePath)
                .NotEmpty().WithMessage("ImagePath is required.");

            RuleFor(vm => vm.ImageName)
                .NotEmpty().WithMessage("ImageName is required.");

            RuleFor(vm => vm.Venue)
                .NotEmpty().WithMessage("Venue is required.");

            RuleFor(vm => vm.StartTime)
                .NotEmpty().WithMessage("StartTime is required.");

            RuleFor(vm => vm.EndTime)
                .NotEmpty().WithMessage("EndTime is required.")
                .GreaterThanOrEqualTo(vm => vm.StartTime).WithMessage("EndTime must be greater than or equal to StartTime.");

            RuleFor(vm => vm.Date)
                .NotEmpty().WithMessage("Date is required.")
                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("Date cannot be in the past.");

        }
    }
}
