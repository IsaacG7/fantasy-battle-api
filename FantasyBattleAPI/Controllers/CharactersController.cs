using FantasyBattleAPI.Models;
using FantasyBattleAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FantasyBattleAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharactersController : ControllerBase
    {
        private CharacterStore _charactersStore;

        public CharactersController(CharacterStore cs)
        {
            _charactersStore = cs;

        }
        [HttpGet(Name = "GetCharacterList")]
        public ActionResult<List<Character>> Get()
        {

            return Ok(_charactersStore.GetAllCharacters());

        }
    }
}

