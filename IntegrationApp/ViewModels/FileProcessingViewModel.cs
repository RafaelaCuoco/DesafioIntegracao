using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationApp.ViewModels
{
    class FileProcessingViewModel
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public decimal productValue { get; set; }
        public DateTime orderDate { get; set; }
    }
}
