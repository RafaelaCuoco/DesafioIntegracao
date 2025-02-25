using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using OrderIntegration.Domain.Entities;
using OrderIntegration.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderIntegration.Core.Services
{
    public class FileProcessorService
    {
        private readonly IUserRepository _userRepository;

        public FileProcessorService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> ProcessFile(string filePath)
        {
            var users = new Dictionary<int, User>();

            List<User> usersList = new List<User>();
            List<Order> orderList = new List<Order>();
            List<Product> productList = new List<Product>();

            foreach (var line in File.ReadLines(filePath))
            {
                // Extrair campos da linha
                int userId = int.Parse(line.Substring(0, 10).TrimStart('0'));
                string name = line.Substring(10, 45).Trim();
                int orderId = int.Parse(line.Substring(55, 10).TrimStart('0'));
                int productId = int.Parse(line.Substring(65, 10).TrimStart('0') == "" ? "0" : line.Substring(65, 10).TrimStart('0'));
                decimal value = decimal.Parse(line.Substring(75, 18).Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                DateTime date = DateTime.ParseExact(line.Substring(87, 8), "yyyyMMdd", CultureInfo.InvariantCulture);

                usersList.Add(new User { UserId = userId, Name = name });
                productList.Add(new Product { ProductId = productId, Value = value, OrderId = orderId });
                orderList.Add(new Order { OrderId = orderId, Date = date, Total = 0, UserId = userId });
            }

            var uniqueUsers = usersList.GroupBy(u => u.UserId).Select(g => g.First()).ToList();

            foreach (var use in uniqueUsers)
            {
                // Criar ou obter o usuário

                var usr = _userRepository.GetUserById(use.UserId);
                if (usr == null)
                {
                    usr = new User { UserId = use.UserId, Name = use.Name };
                }
                users[use.UserId] = usr;


                var user = users[use.UserId];

                var userBanco = users[use.UserId];


                // Criar ou obter o pedido
                var order = orderList.Where(o => o.UserId == use.UserId).ToList();
                if (order != null)
                {
                    user.Orders = order;
                    userBanco.Orders = order;
                }

                // Adicionar produto ao pedido
                foreach (var ord in user.Orders)
                {
                    var prods = productList.Where(p => p.OrderId == ord.OrderId).ToList();
                    ord.Products = prods;
                    decimal total = 0;
                    foreach (var pd in prods)
                    {
                        total += pd.Value;
                    }
                    ord.Total = total;
                }

                foreach (var ord in userBanco.Orders)
                {
                    var prods = productList.Where(p => p.OrderId == ord.OrderId && ord.Products.Where(p => p.ProductId > 0).Count() > 0).ToList();
                    ord.Products = prods;
                    decimal total = 0;
                    foreach (var pd in prods)
                    {
                        total += pd.Value;
                    }
                    ord.Total = total;
                }
                userBanco.Orders = userBanco.Orders.Where(o => o.Products.Count() > 0).ToList();

                //Salvar todos os dados no banco de dados
                _userRepository.AddOrUpdateUser(userBanco);

            }
            return new List<User>(users.Values);
        }
    }
}