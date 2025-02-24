using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderIntegration.Domain.Entities;
using OrderIntegration.Domain.Interfaces;
using OrderIntegration.Infrastructure.Data;

namespace OrderIntegration.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Include(u => u.Orders).ThenInclude(o => o.Products).ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.Products)
                .FirstOrDefault(u => u.UserId == userId);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}