namespace Sinqia.CalculadoraSQIA.Domain.Entidades
{
    public class Cotacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Indexador { get; set; } = default!;
        public decimal Valor { get; set; }

        public decimal CalcularFatorDiario(int quantidadeDias)
        {
            var fator = Math.Pow((double)(1 + Valor / 100), 1.0 / quantidadeDias);
            return Math.Round((decimal)fator, 8);
        }
    }
}
