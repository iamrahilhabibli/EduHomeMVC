using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels
{
    public class BlogCreateViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Title can only contain letters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Author Name can only contain letters")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Image Path is required")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Image Name is required")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Image Name can only contain letters")]
        public string ImageName { get; set; }
        [Required]
        public int CommentCount { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
