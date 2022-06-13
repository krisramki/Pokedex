using Pokedex.ExternalServices.PokeApi;
using Pokedex.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pokedex.ServiceAgent
{
    internal static class DataMapper
    {
        internal static PokemonResponseDto ConvertToPokemonResponseDto(PokemonSpeciesResponse speciesResponse)
        {
            PokemonResponseDto response = new();

            if(speciesResponse != null)
            {
                response.Name = speciesResponse.Name;
                response.Habitat = speciesResponse.Habitat?.Name;
                response.IsLegendary = speciesResponse.IsLegendary;
                response.Description = RemoveEscapeSequenceParameters(speciesResponse.FlavorTextEntries?.FirstOrDefault(
                    x => x.Language?.Name?.ToLower() == "en")?.FlavorText);

            }

            return response;
        }

        private static string RemoveEscapeSequenceParameters(string description)
        {
            return Regex.Replace(description, @"\n|\f", " ");
        }
    }
}
