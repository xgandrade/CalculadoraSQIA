using Sinqia.CalculadoraSQIA.Application.Servicos.Dtos;

namespace Sinqia.CalculadoraSQIA.Application.Servicos.Interfaces
{
    public interface ICalcularSaldoService
    {
        Task<InvestimentoPosFixadoOutputModel> CalcularPosFixado(InvestimentoPosFixadoInputModel investimento);
    }
}
