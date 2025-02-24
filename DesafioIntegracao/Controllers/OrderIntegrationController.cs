using Microsoft.AspNetCore.Mvc;
using OrderIntegration.Core.Services;
using System.IO;
using AutoMapper;
using OrderIntegration.Core.Dtos;

namespace OrderIntegration.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly FileProcessorService _fileProcessor;
        private readonly IMapper _mapper;

        public OrdersController(FileProcessorService fileProcessor, IMapper mapper)
        {
            _fileProcessor = fileProcessor;
            _mapper = mapper;
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

            // Processar o arquivo e obter as entidades
            var users = _fileProcessor.ProcessFile(filePath);

            // Mapear entidades para DTOs usando AutoMapper
            var response = _mapper.Map<List<OrderResponseDto>>(users);

            // Verificar produtos sem ProductId
            var warnings = new List<string>();
            foreach (var user in response)
            {
                foreach (var order in user.Orders)
                {
                    var invalidProducts = order.Products.Where(p => p.ProductId == 0).ToList();
                    if (invalidProducts.Any())
                    {
                        foreach (var product in invalidProducts)
                        {
                            warnings.Add($"Produto sem ID encontrado no pedido {order.OrderId}.");
                        }
                    }
                }
            }

            // Criar a resposta personalizada
            var apiResponse = new ApiResponse
            {
                Success = warnings.Count == 0,
                Message = warnings.Count > 0 ? "Alguns produtos estão sem ID." : "Processamento concluído com sucesso.",
                Data = response,
                Warnings = warnings
            };

            // Retornar a resposta
            if (warnings.Any())
                return StatusCode(206, apiResponse); // Código 206 para advertências
            else
                return Ok(apiResponse); // Código 200 para sucesso total
        }
    }
}