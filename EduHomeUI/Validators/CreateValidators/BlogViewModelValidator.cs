using EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels;
using FluentValidation;

public class BlogViewModelValidator : AbstractValidator<BlogCreateViewModel>
{
    public BlogViewModelValidator()
    {
        RuleFor(vm => vm.Title)
            .NotEmpty().WithMessage("Title is required")
            .Matches("^[A-Za-z ]+$").WithMessage("Title can only contain letters");

        RuleFor(vm => vm.AuthorName)
            .NotEmpty().WithMessage("Author Name is required")
            .Matches("^[A-Za-z]+$").WithMessage("Author Name can only contain letters");

        RuleFor(vm => vm.ImagePath)
            .NotEmpty().WithMessage("Image Path is required");

        RuleFor(vm => vm.ImageName)
            .NotEmpty().WithMessage("Image Name is required")
            .Matches("^[A-Za-z]+$").WithMessage("Image Name can only contain letters");

        //RuleFor(vm => vm.CommentCount)
        //    .NotEmpty().WithMessage("Comment Count is required")
        //    .GreaterThan(0).WithMessage("Comment Count must be greater than 0");

        RuleFor(vm => vm.Description)
            .NotEmpty().WithMessage("Description is required");
    }
}
