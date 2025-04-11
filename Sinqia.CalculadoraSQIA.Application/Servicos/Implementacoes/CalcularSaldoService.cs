using Sinqia.CalculadoraSQIA.Application.Servicos.Dtos;
using Sinqia.CalculadoraSQIA.Application.Servicos.Interfaces;
using Sinqia.CalculadoraSQIA.Domain.Servicos;
using Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Repositories.Interfaces;

namespace Sinqia.CalculadoraSQIA.Application.Servicos.Implementacoes
{
    public class CalcularSaldoService : ICalcularSaldoService
    {
        private readonly ICotacaoRepository _cotacaoRepository;

        public CalcularSaldoService(ICotacaoRepository cotacaoRepository)
        {
            _cotacaoRepository = cotacaoRepository;
        }

        public async Task<InvestimentoPosFixadoOutputModel> CalcularPosFixado(InvestimentoPosFixadoInputModel investimento)
        {
            var cotacoes = await _cotacaoRepository.ObterPorPeriodoAsync(
                investimento.DataAplicacao,
                investimento.DataFinal
            );

            var fatorAcumulado = CalculoFinanceiro.CalcularFatorAcumulado(cotacoes);
            var valorAtualizado = CalculoFinanceiro.CalcularValorAtualizado(investimento.ValorInvestido, fatorAcumulado);

            return new InvestimentoPosFixadoOutputModel
            {
                FatorAcumulado = fatorAcumulado,
                ValorAtualizado = valorAtualizado
            };
        }
    }
}
