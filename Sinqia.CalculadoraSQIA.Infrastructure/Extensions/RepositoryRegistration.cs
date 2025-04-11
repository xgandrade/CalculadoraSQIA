﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Sinqia.CalculadoraSQIA.Infrastructure.Extensions
{
    public static class RepositoryRegistration
    {
        public static void AddInfrastructureRepositories(this IServiceCollection services)
        {
            var infrastructureAssembly = AppDomain.CurrentDomain
                .GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name.Equals("Sinqia.CalculadoraSQIA.Infrastructure", StringComparison.OrdinalIgnoreCase));

            if (infrastructureAssembly is null)
                throw new InvalidOperationException("Infrastructure assembly não encontrado.");

            RegisterRepositories(services, infrastructureAssembly);
        }

        private static void RegisterRepositories(IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"))
                .ToList();

            foreach (var implementationType in types)
            {
                var interfaceType = implementationType.GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{implementationType.Name}");

                if (interfaceType is not null)
                    services.AddScoped(interfaceType, implementationType);
            }
        }
    }
}
