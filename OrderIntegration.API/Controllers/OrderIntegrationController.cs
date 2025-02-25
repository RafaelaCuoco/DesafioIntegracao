using Microsoft.AspNetCore.Mvc;
using OrderIntegration.Core.Services;
using System.IO;
using AutoMapper;
using OrderIntegration.Core.Dtos;
using System.Security.Cryptography;
using OrderIntegration.Domain.Entities;

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
            var response = _mapper.Map<List<OrderResponseDto>>(users).OrderBy(u => u.UserId).ToList();

            // Verificar produtos sem ProductId
            var warnings = new List<string>();

            foreach (var user in response)
            {
                List<OrderDto> prodok = new List<OrderDto>();
                foreach (var order in user.Orders)
                {
                    var invalidProducts = order.Products.Where(p => p.ProductId == 0).ToList();
                    if (invalidProducts.Any())
                    {
                        warnings.Add($"Os seguintes produtos não tiveram o ID encontrado no pedido e não foram cadastrados no banco de dados nem retornados na listagem.");
                        foreach (var product in invalidProducts)
                        {
                            warnings.Add($"User {user.UserId} - {user.Name}. Pedido {order.OrderId}. Valor {order.Total}");
                        }
                    }
                    order.Products = order.Products.Where(p => p.ProductId > 0).ToList();
                    user.Orders = user.Orders.Where(u => u.Products.Count() > 0).ToList();
                }
            }

            // Criar a resposta personalizada
            var apiResponse = new ApiResponse
            {
                Success = warnings.Count == 0,
                Message = warnings.Count > 0 ? "Alguns produtos estão sem ID." : "Processamento concluído com sucesso.",
                Data = response,
                Warnings = warnings.Distinct().ToList()
            };

            // Retornar a resposta
            if (warnings.Any())
                return StatusCode(206, apiResponse); // Código 206 para advertências
            else
                return Ok(apiResponse); // Código 200 para sucesso total
        }
    }
}