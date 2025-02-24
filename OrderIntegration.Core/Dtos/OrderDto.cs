using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderIntegration.Core.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Total { get; set; }
        public string Date { get; set; }
        public List<ProductDto> Products { get; set; } = new();
    }
}
