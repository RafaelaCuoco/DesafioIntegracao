using Microsoft.EntityFrameworkCore;
using OrderIntegration.Infrastructure.Data;
using AutoMapper;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<OrderIntegration.Domain.Interfaces.IUserRepository, OrderIntegration.Infrastructure.Repositories.UserRepository>();
builder.Services.AddScoped<OrderIntegration.Core.Services.FileProcessorService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar o DbContext com a string de conexão
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Registrar o AutoMapper
builder.Services.AddAutoMapper(typeof(OrderIntegration.Core.Mappings.AutoMapperProfile));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Order Integration API",
        Version = "v1",
        Description = "API para integração de pedidos."
    });

    // Adicionar descrições globais de respostas
    c.OperationFilter<GlobalResponseDescriptions>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

// Classe para adicionar descrições globais
public class GlobalResponseDescriptions : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Adicionar descrições globais de respostas
        operation.Responses.TryAdd("206", new OpenApiResponse
        {
            Description = "Requisição retornou dados parciais."
        });

        operation.Responses.TryAdd("500", new OpenApiResponse
        {
            Description = "Erro interno no servidor."
        });
    }
}