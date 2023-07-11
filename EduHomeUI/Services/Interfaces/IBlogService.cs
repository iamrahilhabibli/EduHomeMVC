using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<bool> CreateBlogAsync(BlogCreateViewModel blogVm);
        Task<bool> GetBlogById(Guid blogId);
        Task<Blog> GetBlogByIdBlog(Guid blogId);
        Task<bool> GetBlogDetailById(Guid blogId);
        Task<bool> UpdateBlogDetailIsDeleted(Guid blogDetailId, bool isDeleted);
        Task<bool> UpdateBlogIsDeleted(Guid blogId, bool isDeleted);
    }
}
