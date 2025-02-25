using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderIntegration.Domain.Entities
{
    public class Product
    {
        public int? Id { get; set; } // Nova chave primária (identity/autoincrement)
        public int ProductId { get; set; }
        public decimal Value { get; set; } 
        public int OrderId { get; set; }

        // Relacionamento com Order
        public Order Order { get; set; } 
    }
}
