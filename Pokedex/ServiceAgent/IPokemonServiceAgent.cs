using Pokedex.Models;
using Pokedex.ServiceAgent.ExternalServices;
using System.Threading.Tasks;

namespace Pokedex.ServiceAgent
{
    public interface IPokemonServiceAgent
    {
        Task<ApiResponse<PokemonResponseDto>> GetPokemonDetailsAsync(string name);

        Task<ApiResponse<PokemonResponseDto>> GetTranslatedPokemonDetailsAsync(string name);
    }
}
