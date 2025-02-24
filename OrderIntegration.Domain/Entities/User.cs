using System.Collections.Generic;

namespace OrderIntegration.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        // Relacionamento com Order
        public List<Order> Orders { get; set; } = new();
    }
}