using System.Threading.Tasks;

namespace Pokedex.ExternalServices.PokeApi
{
    public interface IPokeApi
    {
        Task<PokemonSpeciesResponse> GetPokemonSpeciesAsync(string name);
    }
}
