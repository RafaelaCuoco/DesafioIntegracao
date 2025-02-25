using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

        public User GetUserById(int userId)
        {
            return _context.Users.Include(u => u.Orders).ThenInclude(o => o.Products).FirstOrDefault(u => u.UserId == userId);
        }

        public void AddOrUpdateUser(User user)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var Orders = user.Orders;
                    var Products = Orders.SelectMany(o => o.Products).ToList();

                    user.Orders = null;

                    var existingUser = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
                    if (existingUser == null)
                    {
                        _context.Users.Add(user);
                    }
                    else
                    {
                        _context.Entry(existingUser).CurrentValues.SetValues(user);
                    }

                    // Salvar alterações para Users
                    _context.SaveChanges();

                    // Processar Orders
                    foreach (var order in Orders)
                    {
                        var existingOrder = _context.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
                        if (existingOrder == null)
                        {
                            _context.Orders.Add(order);
                        }
                        else
                        {
                            _context.Entry(existingOrder).CurrentValues.SetValues(order);
                        }

                        // Salvar alterações para Orders
                        _context.SaveChanges();

                        // Processar Products
                        foreach (var product in order.Products)
                        {
                            var existingProduct = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                            if (existingProduct == null)
                            {
                                _context.Products.Add(product);
                            }
                            //else
                            //{
                            //    _context.Entry(existingProduct).CurrentValues.SetValues(product);
                            //}

                            // Salvar alterações para Products
                            _context.SaveChanges();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}