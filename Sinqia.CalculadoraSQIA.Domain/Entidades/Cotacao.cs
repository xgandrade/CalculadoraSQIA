namespace Sinqia.CalculadoraSQIA.Domain.Entidades
{
    public class Cotacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Indexador { get; set; } = default!;
        public decimal Valor { get; set; }

        protected Cotacao() { }

        public Cotacao(DateTime data, string indexador, decimal valor)
        {
            if (string.IsNullOrWhiteSpace(indexador))
                throw new ArgumentException("Indexador não pode ser vazio.");

            if (valor < 0)
                throw new ArgumentException("Valor da cotação não pode ser negativo.");

            Data = data;
            Indexador = indexador;
            Valor = valor;
        }

        public decimal CalcularFatorDiario(int quantidadeDias)
        {
            var fator = Math.Pow((double)(1 + Valor / 100), 1.0 / quantidadeDias);
            return Math.Round((decimal)fator, 8);
        }
    }
}
