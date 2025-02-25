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

            // Configuração da entidade Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id); // Define Id como chave primária
                entity.Property(p => p.Id).ValueGeneratedOnAdd(); // Autoincrement/Identity
                entity.Property(p => p.ProductId).IsRequired(); // ProdutoId agora é apenas um campo
                entity.Property(p => p.Value).HasPrecision(18, 10).IsRequired();
            });

            // Outras configurações (User, Order, etc.)
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(45);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);
                entity.Property(o => o.Date).IsRequired();
                entity.Property(o => o.Total).HasPrecision(18, 10).IsRequired();
            });
        }
    }
}