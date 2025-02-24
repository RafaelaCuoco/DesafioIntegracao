using IntegrationApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationApp.Interfaces
{
    public interface IFileProcessingService
    {
        IEnumerable<FileProcessingViewModel> ProcessFileAsync(IFormFile file);
    }
}
