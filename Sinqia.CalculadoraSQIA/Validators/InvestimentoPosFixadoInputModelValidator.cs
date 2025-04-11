using FluentValidation;
using Sinqia.CalculadoraSQIA.Application.Servicos.Dtos;

namespace Sinqia.CalculadoraSQIA.Api.Validators
{
    public class InvestimentoPosFixadoInputModelValidator : AbstractValidator<InvestimentoPosFixadoInputModel>
    {
        public InvestimentoPosFixadoInputModelValidator()
        {
            RuleFor(x => x.ValorInvestido)
                .GreaterThan(0).WithMessage("O valor investido deve ser maior que zero.");

            RuleFor(x => x.DataAplicacao)
                .LessThan(x => x.DataFinal)
                .WithMessage("A data de aplicação deve ser anterior à data final.");
        }
    }
}
