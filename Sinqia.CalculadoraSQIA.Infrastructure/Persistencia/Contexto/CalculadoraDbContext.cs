using Microsoft.EntityFrameworkCore;
using Sinqia.CalculadoraSQIA.Domain.Entidades;

namespace Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Contexto
{
    public class CalculadoraDbContext : DbContext
    {
        public CalculadoraDbContext(DbContextOptions<CalculadoraDbContext> options) : base(options) { }

        public DbSet<Cotacao> Cotacoes => Set<Cotacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cotacao>()
                .Property(cotacao => cotacao.Valor)
                .HasPrecision(18, 6);

            base.OnModelCreating(modelBuilder);
        }
    }
}
