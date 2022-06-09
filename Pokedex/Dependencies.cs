using Microsoft.Extensions.DependencyInjection;
using Pokedex.ExternalServices.FunTranslationsApi;
using Pokedex.ExternalServices.PokeApi;
using Pokedex.ServiceAgent;

namespace Pokedex
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPokemonServiceAgent, PokemonServiceAgent>();
            services.AddScoped<IPokeApi, PokeApi>();
            services.AddScoped<IFunTranslationsApi, FunTranslationsApi>();

            return services;
        }
    }
}
