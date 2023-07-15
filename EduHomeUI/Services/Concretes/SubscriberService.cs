using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class SubscriberService:ISubscriberService
    {
        private readonly AppDbContext _context;
        public SubscriberService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Subscribers>> GetAllSubscribersAsync()
        {
            return await _context.Subscribers.ToListAsync();
        }
        public async Task<bool> IsUserSubscribed(string email)
        {
            return await _context.Subscribers.AnyAsync(s => s.Email == email);
        }
        public async Task AddSubscriberAsync(string email, string userId)
        {
            Subscribers newSub = new Subscribers
            {
                Email = email,
                UserId = Guid.Parse(userId)
            };

            await _context.Subscribers.AddAsync(newSub);
            await _context.SaveChangesAsync();
        }
    }
}
