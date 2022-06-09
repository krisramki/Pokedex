using Pokedex.Models;
using System.Threading.Tasks;

namespace Pokedex.ServiceAgent
{
    public interface IPokemonServiceAgent
    {
        Task<PokemonResponseDto> GetPokemonDetailsAsync(string name);

        Task<PokemonResponseDto> GetTranslatedPokemonDetailsAsync(string name);
    }
}
