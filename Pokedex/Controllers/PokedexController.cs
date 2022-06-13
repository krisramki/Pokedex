using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.ServiceAgent;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokedexController : ControllerBase
    {
        private readonly IPokemonServiceAgent pokemonServiceAgent;

        public PokedexController(IPokemonServiceAgent pokemonServiceAgent)
        {
            this.pokemonServiceAgent = pokemonServiceAgent;
        }



        [HttpGet("{pokemonName}")]
        [ResponseType(typeof(PokemonResponseDto))]
        public async Task<IActionResult> GetBasicPokemonDetails([Required]string pokemonName)
        {
            var response = await pokemonServiceAgent.GetPokemonDetailsAsync(pokemonName);

            return response.Success ? Ok(response.Result) : BadRequest();
        }


        [HttpGet("translated/{pokemonName}")]
        [ResponseType(typeof(PokemonResponseDto))]
        public async Task<IActionResult> GetPokemonWithTranslatedDescription([Required]string pokemonName)
        {
            var response = await pokemonServiceAgent.GetTranslatedPokemonDetailsAsync(pokemonName);

            return response.Success ? Ok(response.Result) : BadRequest();
        }
    }
}
