using EduHome.Core.Entities;

namespace EduHomeUI.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllBlogsAsync();
    }
}
