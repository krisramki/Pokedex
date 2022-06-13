using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.ExternalServices.PokeApi
{
    public class PokeApi : IPokeApi
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string baseUrl;

        public PokeApi(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            baseUrl = configuration.GetSection("ExternalServicesUrl").GetSection("PokeApiBaseUrl").Value;
        }

        public async Task<PokemonSpeciesResponse> GetPokemonSpeciesAsync(string pokemonName)
        {
            var httpClient = httpClientFactory.CreateClient();
            var httpResponse = await httpClient.GetAsync($"{baseUrl}pokemon-species/{pokemonName}");

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            var result = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PokemonSpeciesResponse>(result);
        }
    }
}
