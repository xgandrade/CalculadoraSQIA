using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinqia.CalculadoraSQIA.Domain.Entidades
{
    public class Cotacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Indexador { get; set; } = default!;
        public decimal Valor { get; set; }
    }
}
