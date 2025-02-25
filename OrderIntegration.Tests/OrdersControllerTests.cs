using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace OrderIntegration.IntegrationTests
{
    public class OrdersControllerTests : IClassFixture<WebApplicationFactory<OrderIntegration.API.ApiResponse>>
    {
        private readonly HttpClient _client;

        public OrdersControllerTests(WebApplicationFactory<OrderIntegration.API.ApiResponse> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task UploadFile_ShouldReturnBadRequest_WhenNoFileIsProvided()
        {
            // Act: Enviar uma requisição sem arquivo
            var response = await _client.PostAsync("/api/orders/upload", null);

            // Assert: Verificar o status da resposta
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

            // Ler o corpo da resposta como JSON
            var responseBody = await response.Content.ReadAsStringAsync();
            var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(responseBody);

            // Verificar se o campo 'errors.file' contém a mensagem esperada
            errorResponse.errors.file.Should().Contain("The file field is required.");
        }
    }

    // Classe auxiliar para desserializar a resposta de erro
    public class ErrorResponse
    {
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public ErrorDetails errors { get; set; }
        public string traceId { get; set; }
    }

    public class ErrorDetails
    {
        public string[] file { get; set; }
    }
}