using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinqia.CalculadoraSQIA.Application.Servicos.Dtos
{
    public class InvestimentoPosFixadoInputModel
    {
        public decimal ValorInvestido { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
