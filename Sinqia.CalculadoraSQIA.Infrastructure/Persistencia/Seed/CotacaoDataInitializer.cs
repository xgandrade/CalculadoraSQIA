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
                new () { Data = new DateTime(2025, 1, 1),  Indexador = "SQI", Valor = 10.50m },
                new () { Data = new DateTime(2025, 1, 2),  Indexador = "SQI", Valor = 10.50m },
                new () { Data = new DateTime(2025, 1, 3),  Indexador = "SQI", Valor = 10.50m },
                new () { Data = new DateTime(2025, 1, 6),  Indexador = "SQI", Valor = 12.25m },
                new () { Data = new DateTime(2025, 1, 7),  Indexador = "SQI", Valor = 12.25m },
                new () { Data = new DateTime(2025, 1, 8),  Indexador = "SQI", Valor = 12.25m },
                new () { Data = new DateTime(2025, 1, 9),  Indexador = "SQI", Valor = 12.25m },
                new () { Data = new DateTime(2025, 1, 10), Indexador = "SQI", Valor = 12.25m },
                new () { Data = new DateTime(2025, 1, 13), Indexador = "SQI", Valor = 12.25m },
                new () { Data = new DateTime(2025, 1, 14), Indexador = "SQI", Valor = 12.25m },
                new () { Data = new DateTime(2025, 1, 15), Indexador = "SQI", Valor = 12.25m },
                new () { Data = new DateTime(2025, 1, 16), Indexador = "SQI", Valor = 9.00m},
                new () { Data = new DateTime(2025, 1, 17), Indexador = "SQI", Valor = 9.00m },
                new () { Data = new DateTime(2025, 1, 20), Indexador = "SQI", Valor = 9.00m },
                new () { Data = new DateTime(2025, 1, 21), Indexador = "SQI", Valor = 7.75m },
                new () { Data = new DateTime(2025, 1, 22), Indexador = "SQI", Valor = 7.75m },
                new () { Data = new DateTime(2025, 1, 23), Indexador = "SQI", Valor = 7.75m },
                new () { Data = new DateTime(2025, 1, 24), Indexador = "SQI", Valor = 7.75m },
                new () { Data = new DateTime(2025, 1, 27), Indexador = "SQI", Valor = 8.25m },
                new () { Data = new DateTime(2025, 1, 28), Indexador = "SQI", Valor = 8.25m },
                new () { Data = new DateTime(2025, 1, 29), Indexador = "SQI", Valor = 8.25m },
                new () { Data = new DateTime(2025, 1, 30), Indexador = "SQI", Valor = 8.25m },
                new () { Data = new DateTime(2025, 1, 31), Indexador = "SQI", Valor = 8.25m },
            };

            context.Cotacoes.AddRange(cotacoes);
            context.SaveChanges();
        }
    }
}
