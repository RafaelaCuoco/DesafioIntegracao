using Microsoft.AspNetCore.Mvc;
using OrderIntegration.Core.Dtos;
using OrderIntegration.Core.Services;
using System.IO;

namespace DesafioIntegracao.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly FileProcessorService _fileProcessor;

    public OrdersController(FileProcessorService fileProcessor)
    {
        _fileProcessor = fileProcessor;
    }

    [HttpPost("upload")]
    public IActionResult UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Arquivo inválido.");

        var filePath = Path.GetTempFileName();
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        var users = _fileProcessor.ProcessFile(filePath);
        var response = users.Select(static u => new OrderResponseDto
        {
            UserId = u.UserId,
            Name = u.Name,
            Orders = u.Orders.Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                Date = o.Date.ToString("yyyy-MM-dd"),
                Total = o.Total.ToString("F2"),
                Products = o.Products.Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Value = Convert.ToDecimal(p.Value.ToString("F2"))
                }).ToList()
            }).ToList()
        }).ToList();

        return Ok(response);
    }
}