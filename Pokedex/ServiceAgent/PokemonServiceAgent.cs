using Microsoft.Extensions.Logging;
using Pokedex.ExternalServices.FunTranslationsApi;
using Pokedex.ExternalServices.PokeApi;
using Pokedex.Models;
using Pokedex.ServiceAgent.ExternalServices;
using System;
using System.Threading.Tasks;

namespace Pokedex.ServiceAgent
{
    public class PokemonServiceAgent : IPokemonServiceAgent
    {
        private readonly IPokeApi pokeApi;
        private readonly IFunTranslationsApi funTranslationsApi;
        private readonly ILogger<PokemonServiceAgent> logger;

        public PokemonServiceAgent(IPokeApi pokeApi, 
            IFunTranslationsApi funTranslationsApi, ILogger<PokemonServiceAgent> logger)
        {
            this.pokeApi = pokeApi;
            this.funTranslationsApi = funTranslationsApi;
            this.logger = logger;
        }

        public async Task<ApiResponse<PokemonResponseDto>> GetPokemonDetailsAsync(string pokemonName)
        { 
            
            var result = await pokeApi.GetPokemonSpeciesAsync(pokemonName);

            var response = DataMapper.ConvertToPokemonResponseDto(result);

            return new ApiResponse<PokemonResponseDto>(response);
        }

        public async Task<ApiResponse<PokemonResponseDto>> GetTranslatedPokemonDetailsAsync(string pokemonName)
        {
            var response = await GetPokemonDetailsAsync(pokemonName);
            
            bool exceptionThrown = false;

            if (response.Success && response.Result.Description != null)
            {
                string newDescription = string.Empty;
                
                if (response.Result.Habitat?.ToLower() == "cave" || response.Result.IsLegendary)
                {
                    try
                    {
                        newDescription = (await funTranslationsApi.GetYodaTranslation(response.Result.Description)).Contents.Translated;
                    }
                    catch(Exception ex)
                    {
                        exceptionThrown = true;
                        logger.LogError(ex, ex.Message);
                    }
                }
                
                if (exceptionThrown || string.IsNullOrWhiteSpace(newDescription))
                {
                    try
                    {
                        newDescription = (await funTranslationsApi.GetShakespeareTranslation(response.Result.Description)).Contents.Translated;
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, ex.Message);
                    }
                }


                if (!string.IsNullOrEmpty(newDescription))
                {
                    response.Result.Description = newDescription;
                }
            }

            return response;
        }
    }
}
