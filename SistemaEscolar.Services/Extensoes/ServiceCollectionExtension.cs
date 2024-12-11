using Microsoft.Extensions.DependencyInjection;
using SistemaEscolar.Services.Implementacoes;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Extensoes
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEscolaService, EscolaService>();
            return services;
        }
    }
}
