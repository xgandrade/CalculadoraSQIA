using Sinqia.CalculadoraSQIA.Domain.Entidades;

namespace Sinqia.CalculadoraSQIA.Tests.Domain.Entidades
{
    public class CotacaoTests
    {
        [Fact]
        public void DeveCriarCotacao()
        {
            var data = new DateTime(2024, 4, 10);
            var indexador = "SQI";
            var valor = 13.75m;

            var cotacao = new Cotacao(data, indexador, valor);

            Assert.Equal(data, cotacao.Data);
            Assert.Equal(indexador, cotacao.Indexador);
            Assert.Equal(valor, cotacao.Valor);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void IndexadorInvalido_NaoDeveCriarCotacao(string indexadorInvalido)
        {
            var data = DateTime.Now;
            var valor = 10m;

            var ex = Assert.Throws<ArgumentException>(() => new Cotacao(data, indexadorInvalido, valor));
            Assert.Equal("Indexador não pode ser vazio.", ex.Message);
        }

        [Fact]
        public void ValorNegativo_NaoDeveCriarCotacao()
        {
            var data = DateTime.Now;
            var indexador = "CDI";
            var valor = -5m;

            var ex = Assert.Throws<ArgumentException>(() => new Cotacao(data, indexador, valor));
            Assert.Equal("Valor da cotação não pode ser negativo.", ex.Message);
        }

        [Fact]
        public void CotacaoValida_DeveCalcularCorretamenteOFatorDiario()
        {
            var cotacao = new Cotacao(DateTime.Today, "SQI", 13.65m);
            var diasUteisAno = 252;

            var fator = cotacao.CalcularFatorDiario(diasUteisAno);
            var esperado = Math.Round((decimal)Math.Pow(1 + 13.65 / 100, 1.0 / diasUteisAno), 8);

            Assert.Equal(esperado, fator);
        }
    }
}
