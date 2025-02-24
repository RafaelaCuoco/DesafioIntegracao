using Microsoft.EntityFrameworkCore;
using OrderIntegration.Domain.Entities;

namespace OrderIntegration.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Construtor padrão (usado pelo EF Core para migrações)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para cada entidade do domínio
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        // Configuração das entidades e relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId); // Chave primária
                entity.Property(u => u.Name).IsRequired().HasMaxLength(45);

                // Relacionamento 1:N com Order
                entity.HasMany(u => u.Orders) // Um usuário pode ter muitos pedidos
                      .WithOne(o => o.User)   // Um pedido pertence a um usuário
                      .HasForeignKey(o => o.UserId) // Chave estrangeira em Order
                      .OnDelete(DeleteBehavior.Cascade); // Excluir pedidos ao excluir usuário
            });

            // Configuração da entidade Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId); // Chave primária
                entity.Property(o => o.Date).IsRequired();
                entity.Property(o => o.Total)
                      .HasPrecision(18, 10) // Define precisão 18 e escala 10
                      .IsRequired();

                // Relacionamento 1:N com Product
                entity.HasMany(o => o.Products) // Um pedido pode ter muitos produtos
                      .WithOne(p => p.Order)    // Um produto pertence a um pedido
                      .HasForeignKey(p => p.OrderId) // Chave estrangeira em Product
                      .OnDelete(DeleteBehavior.Cascade); // Excluir produtos ao excluir pedido
            });

            // Configuração da entidade Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId); // Chave primária
                entity.Property(p => p.Value)
                      .HasPrecision(18, 10) // Define precisão 18 e escala 10
                      .IsRequired();
            });
        }
    }
}