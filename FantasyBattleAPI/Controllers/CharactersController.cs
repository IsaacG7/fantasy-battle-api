using FantasyBattleAPI.Models;
using FantasyBattleAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FantasyBattleAPI.DTOs;
using Microsoft.AspNetCore.JsonPatch;
namespace FantasyBattleAPI.Controllers
{
    // This says this will be an api controller which gives us some 
    // "Baked in" capabilities like automatic model validation
    [ApiController]

    // this says any requests starting with api/Characters will be handled by this controller
    [Route("api/[Controller]")]
    public class CharactersController : ControllerBase
    {
        private CharacterServiceAgent _characterServiceAgent;

        public CharactersController(CharacterServiceAgent cs)
        {
            _characterServiceAgent = cs;

        }


        [HttpGet(Name = "GetCharacterList")]
        // ActionResult allows us to return the list of characters in JSON
        // Or error codes
        public ActionResult<List<Character>> GetAll()
        {
            return Ok(_characterServiceAgent.GetAllCharacters());
        }


        [HttpGet("{id}", Name = "GetCharacterByID")]
        public ActionResult<Character> GetByID(int id)
        {
            var character = _characterServiceAgent.GetCharacterById(id);

            if (character != null)
            {
                return Ok(character);

            }
            return NotFound();
        }


        [HttpPost(Name = "CreateCharacter")]
        public ActionResult<Character> CreateCharacter(CreateCharacterDto c)
        {
            var character = new Character
            {
                Hp = c.Hp,
                Attack = c.Attack,
                Defense = c.Defense,
                Race = c.Race,
                CharacterClass = c.CharacterClass,
                Name = c.Name,
                Level = c.Level,
            };
            if (_characterServiceAgent.AddCharacter(character))
            {
                return CreatedAtAction("GetByID", new { id = character.Id }, character);
            }
            return BadRequest();

        }


        [HttpDelete("{id}", Name = "DeleteCharacterByID")]
        public IActionResult DeleteCharacter(int id)
        {
            var result = _characterServiceAgent.RemoveCharacter(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch("{id}", Name = "UpdateCharacter")]
        public IActionResult UpdateCharacter(int id, [FromBody] PatchCharacterDto patchCharacter)
        {
            var result = _characterServiceAgent.UpdateCharacter(id, patchCharacter);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

