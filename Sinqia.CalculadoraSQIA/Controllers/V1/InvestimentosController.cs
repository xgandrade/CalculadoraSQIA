using Microsoft.AspNetCore.Mvc;
using Sinqia.CalculadoraSQIA.Application.Servicos.Dtos;
using Sinqia.CalculadoraSQIA.Application.Servicos.Interfaces;

namespace Sinqia.CalculadoraSQIA.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/investimentos/pos-fixado")]
    public class InvestimentosController : ControllerBase
    {
        private ICalcularSaldoService _service;

        public InvestimentosController(ICalcularSaldoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Calcular([FromBody] InvestimentoPosFixadoInputModel dto)
        {
            var resultado = await _service.CalcularPosFixado(dto);
            return Ok(resultado);
        }
    }
}
