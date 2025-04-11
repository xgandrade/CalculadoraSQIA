using Sinqia.CalculadoraSQIA.Domain.Entidades;
using Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Contexto;

namespace Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Seed
{
    public class CotacaoDataInitializer
    {
        public void Initialize(CalculadoraDbContext context)
        {
            if (context.Cotacoes.Any())
                return;

            List<Cotacao> cotacoes = new()
            {
                new (new DateTime(2025, 1, 1), "SQI", 10.50m),
                new (new DateTime(2025, 1, 2), "SQI", 10.50m),
                new (new DateTime(2025, 1, 3), "SQI", 10.50m),
                new (new DateTime(2025, 1, 6), "SQI", 12.25m),
                new (new DateTime(2025, 1, 7), "SQI", 12.25m),
                new (new DateTime(2025, 1, 8), "SQI", 12.25m),
                new (new DateTime(2025, 1, 9), "SQI", 12.25m),
                new (new DateTime(2025, 1, 10), "SQI", 12.25m),
                new (new DateTime(2025, 1, 13), "SQI", 12.25m),
                new (new DateTime(2025, 1, 14), "SQI", 12.25m),
                new (new DateTime(2025, 1, 15), "SQI", 12.25m),
                new (new DateTime(2025, 1, 16), "SQI", 9.00m),
                new (new DateTime(2025, 1, 17), "SQI", 9.00m),
                new (new DateTime(2025, 1, 20), "SQI", 9.00m),
                new (new DateTime(2025, 1, 21), "SQI", 7.75m),
                new (new DateTime(2025, 1, 22), "SQI", 7.75m),
                new (new DateTime(2025, 1, 23), "SQI", 7.75m),
                new (new DateTime(2025, 1, 24), "SQI", 7.75m),
                new (new DateTime(2025, 1, 27), "SQI", 8.25m),
                new (new DateTime(2025, 1, 28), "SQI", 8.25m),
                new (new DateTime(2025, 1, 29), "SQI", 8.25m),
                new (new DateTime(2025, 1, 30), "SQI", 8.25m),
                new (new DateTime(2025, 1, 31), "SQI", 8.25m),
            };

            context.Cotacoes.AddRange(cotacoes);
            context.SaveChanges();
        }
    }
}
