using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Models;
using System.Web.Http.Description;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokedexController : ControllerBase
    {
        private readonly ILogger<PokedexController> _logger;

        public PokedexController(ILogger<PokedexController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{pokemonName}")]
        [ResponseType(typeof(PokemonResponseDto))]
        public IActionResult GetBasicPokemonDetails(string pokemonName)
        {
            PokemonResponseDto response = new();
            return Ok(response);
        }


        [HttpGet("translated/{pokemonName}")]
        [ResponseType(typeof(PokemonResponseDto))]
        public IActionResult GetPokemonWithTranslatedDescription(string pokemonName)
        {
            PokemonResponseDto response = new();
            return Ok(response);
        }
    }
}
