using FantasyBattleAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBattleAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharactersController : ControllerBase
    {
        private CharacterStore _charactersStore;

        public CharactersController(CharacterStore cs) {
            _charactersStore = cs;

        }
    }
}
