using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels
{
    public class BlogCreateViewModel
    {
     
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string ImagePath { get; set; }

        public string ImageName { get; set; }

        public int CommentCount { get; set; }
        public string Description { get; set; }
    }
}
