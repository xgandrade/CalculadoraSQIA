using Microsoft.EntityFrameworkCore;
using Sinqia.CalculadoraSQIA.Domain.Entidades;
using Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Contexto;
using Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Repositories.Interfaces;

namespace Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Repositories.Implementacoes
{
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly CalculadoraDbContext _context;

        public CotacaoRepository(CalculadoraDbContext context)
        {
            _context = context;
        }

        bool IsDiaUtil(DateTime data) => data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday;

        public async Task<List<Cotacao>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            var cotacoes = await _context.Cotacoes
                                            .Where(c => c.Data >= dataInicio && c.Data <= dataFim)
                                            .ToListAsync();

            return cotacoes
                .Where(c => IsDiaUtil(c.Data))
                .OrderBy(c => c.Data)
                .ToList();
        }
    }
}
