using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.UserReplyViewModel.cs;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserReplyCreateViewModel userReply)
        {
            UserReply newUserReply = new()
            {
                Name = userReply.Name,
                Subject = userReply.Subject,
                Email = userReply.Email,
                Body = userReply.Message
            };
            _context.UserReplies.Add(newUserReply);
            _context.SaveChanges();
            TempData["Success"] = "Reply Sent Successfully";
            return View(newUserReply);
        }
    }
}
