using Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Contexto;

namespace Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Seed
{
    public static class DbInitializer
    {
        public static void Seed(CalculadoraDbContext context)
        {
            try
            {
                new CotacaoDataInitializer().Initialize(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro durante execução dos seeds: " + ex.Message);
                throw;
            }
        }
    }
}