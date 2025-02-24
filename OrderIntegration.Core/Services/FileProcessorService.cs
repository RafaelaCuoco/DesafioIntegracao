using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using OrderIntegration.Domain.Entities;

namespace OrderIntegration.Core.Services
{
    public class FileProcessorService
    {
        public List<User> ProcessFile(string filePath)
        {
            var users = new Dictionary<int, User>();

            foreach (var line in File.ReadLines(filePath))
            {
                // Extrair campos da linha
                var userId = int.Parse(line.Substring(0, 10).TrimStart('0'));
                var name = line.Substring(10, 45).Trim();
                var orderId = int.Parse(line.Substring(55, 10).TrimStart('0'));
                var productId = line.Substring(65, 10).TrimStart('0');
                var value = decimal.Parse(line.Substring(75, 18).Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                var date = DateTime.ParseExact(line.Substring(87, 8), "yyyyMMdd", CultureInfo.InvariantCulture);

                // Criar ou obter o usuário
                if (!users.ContainsKey(userId))
                {
                    users[userId] = new User { UserId = userId, Name = name };
                }

                var user = users[userId];

                // Criar ou obter o pedido
                var order = user.Orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                {
                    order = new Order { OrderId = orderId, Date = date, Total = 0 };
                    user.Orders.Add(order);
                }

                // Adicionar produto ao pedido
                order.Total += value;
                order.Products.Add(new Product { ProductId = productId, Value = value });
            }

            return new List<User>(users.Values);
        }
    }
}