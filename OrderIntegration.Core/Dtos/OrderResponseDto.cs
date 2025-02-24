using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderIntegration.Core.Dtos
{
    public class OrderResponseDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<OrderDto> Orders { get; set; } = new();
    }
}
