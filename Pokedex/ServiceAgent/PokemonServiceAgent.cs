using Pokedex.ExternalServices.FunTranslationsApi;
using Pokedex.ExternalServices.PokeApi;
using Pokedex.Models;
using System.Threading.Tasks;

namespace Pokedex.ServiceAgent
{
    public class PokemonServiceAgent : IPokemonServiceAgent
    {
        private readonly IPokeApi pokeApi;
        private readonly IFunTranslationsApi funTranslationsApi;

        public PokemonServiceAgent(IPokeApi pokeApi, IFunTranslationsApi funTranslationsApi)
        {
            this.pokeApi = pokeApi;
            this.funTranslationsApi = funTranslationsApi;
        }

        public async Task<PokemonResponseDto> GetPokemonDetailsAsync(string name)
        { 
            
            var result = await pokeApi.GetPokemonSpeciesAsync(name);

            var response = DataMapper.ConvertToPokemonResponseDto(result);

            return response;

        }

        public async Task<PokemonResponseDto> GetTranslatedPokemonDetailsAsync(string name)
        {
            var response = await GetPokemonDetailsAsync(name);
            string newDescription;

            if (response.Habitat?.ToLower() == "cave" || response.IsLegendary)
            {
                newDescription = (await funTranslationsApi.GetYodaTranslation(response.Description)).Contents.Translated;
            }
            else
            {
                newDescription = (await funTranslationsApi.GetShakespeareTranslation(response.Description)).Contents.Translated;
            }


            if (!string.IsNullOrEmpty(newDescription))
            {
                response.Description = newDescription;
            }

            return response;
        }
    }
}
