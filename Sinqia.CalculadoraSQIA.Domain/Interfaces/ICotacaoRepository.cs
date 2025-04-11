using Sinqia.CalculadoraSQIA.Domain.Entidades;

namespace Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Repositories.Interfaces
{
    public interface ICotacaoRepository
    {
        Task<List<Cotacao>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
    }
}
