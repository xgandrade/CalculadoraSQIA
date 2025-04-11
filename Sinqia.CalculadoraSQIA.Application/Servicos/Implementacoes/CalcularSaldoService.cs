using Sinqia.CalculadoraSQIA.Application.Servicos.Dtos;
using Sinqia.CalculadoraSQIA.Application.Servicos.Interfaces;
using Sinqia.CalculadoraSQIA.Domain.Entidades;
using Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Repositories.Interfaces;

namespace Sinqia.CalculadoraSQIA.Application.Servicos.Implementacoes
{
    public class CalcularSaldoService : ICalcularSaldoService
    {
        private readonly ICotacaoRepository _cotacaoRepository;
        private const decimal TRUNCAMENTO_DECIMAL_16_CASAS = 10000000000000000m;
        private const decimal TRUNCAMENTO_DECIMAL_8_CASAS = 100000000m;
        private const int DIAS_UTEIS_ANO = 252;

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

            if (!cotacoes.Any())
                throw new InvalidOperationException("Não foram encontradas cotações no período informado.");

            var fatorAcumulado = CalcularFatorAcumulado(cotacoes);
            var valorAtualizado = CalcularValorAtualizado(investimento.ValorInvestido, fatorAcumulado);

            return new InvestimentoPosFixadoOutputModel
            {
                FatorAcumulado = fatorAcumulado,
                ValorAtualizado = valorAtualizado
            };
        }

        private decimal CalcularFatorAcumulado(List<Cotacao> cotacoes)
        {
            decimal fatorAcumulado = 1;
            for (int i = 1; i < cotacoes.Count; i++)
                fatorAcumulado *= cotacoes[i - 1].CalcularFatorDiario(DIAS_UTEIS_ANO);

            return Truncar(fatorAcumulado, TRUNCAMENTO_DECIMAL_16_CASAS);
        }

        private decimal CalcularValorAtualizado(decimal valor, decimal fatorAcumulado) => Truncar(valor * fatorAcumulado, TRUNCAMENTO_DECIMAL_8_CASAS);

        private decimal Truncar(decimal valor, decimal precisao) => Math.Truncate(valor * precisao) / precisao;
    }
}
