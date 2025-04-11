using Sinqia.CalculadoraSQIA.Domain.Entidades;

namespace Sinqia.CalculadoraSQIA.Domain.Servicos
{
    public class CalculoFinanceiro
    {
        private const decimal TRUNCAMENTO_DECIMAL_16_CASAS = 10000000000000000m;
        private const decimal TRUNCAMENTO_DECIMAL_8_CASAS = 100000000m;
        private const int DIAS_UTEIS_ANO = 252;

        public static decimal CalcularFatorAcumulado(List<Cotacao> cotacoes)
        {
            decimal fatorAcumulado = 1;

            for (int i = 1; i < cotacoes.Count; i++)
            {
                var fatorDiario = CalcularFatorDiario(cotacoes[i - 1].Valor);
                fatorAcumulado *= fatorDiario;
            }

            return Truncar(fatorAcumulado, TRUNCAMENTO_DECIMAL_16_CASAS);
        }

        public static decimal CalcularFatorDiario(decimal taxaAnual)
        {
            var fator = Math.Pow((double)(1 + taxaAnual / 100), 1.0 / DIAS_UTEIS_ANO);
            return Math.Round((decimal)fator, 8);
        }

        public static decimal CalcularValorAtualizado(decimal valor, decimal fatorAcumulado) => Truncar(valor * fatorAcumulado, TRUNCAMENTO_DECIMAL_8_CASAS);

        private static decimal Truncar(decimal valor, decimal precisao) => Math.Truncate(valor * precisao) / precisao;
    }
}
