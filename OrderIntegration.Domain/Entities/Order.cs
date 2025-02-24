using System;
using System.Collections.Generic;

namespace OrderIntegration.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        // Chave estrangeira para User
        public int UserId { get; set; }

        // Propriedade de navegação para User
        public User User { get; set; }

        // Relacionamento com Product
        public List<Product> Products { get; set; } = new();
    }
}