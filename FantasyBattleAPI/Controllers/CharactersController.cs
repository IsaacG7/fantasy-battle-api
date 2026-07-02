using FantasyBattleAPI.Models;
using FantasyBattleAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FantasyBattleAPI.Controllers
{
    // This says this will be an api controller which gives us some 
    // "Baked in" capabilities like automatic model validation
    [ApiController]

    // this says any requests starting with api/Characters will be handled by this controller
    [Route("api/[Controller]")]
    public class CharactersController : ControllerBase
    {
        private CharacterStore _characterStore;

        // Because we registered CharacterStore as a singleton (builder.Services.AddSingleton<CharacterStore>();)
        // When the framework constructs this controller it looks for the CharacterStore
        // in the DI container which provides the singleton object and it is injected through cs
        public CharactersController(CharacterStore cs)
        {
            _characterStore = cs;

        }


        [HttpGet(Name = "GetCharacterList")]
        // ActionResult allows us to return the list of characters in JSON
        // Or error codes
        public ActionResult<List<Character>> GetAll()
        {
            return Ok(_characterStore.GetAllCharacters());
        }


        [HttpGet("{id}", Name = "GetCharacterByID")]
        public ActionResult<Character> GetByID(int id)
        {
            var character = _characterStore.GetCharacterById(id);

            if (character != null)
            {
                return Ok(character);

            }
            return NotFound();
        }


        [HttpPost(Name = "CreateCharacter")]
        public ActionResult<Character> CreateCharacter(Character ch)
        {
            if (_characterStore.AddCharacter(ch))
            {

                // Returns 201(new resource created) with a Location header pointing to the new character's GET endpoint,
                // and the newly created character in the response body.
                return CreatedAtAction("GetByID", new { id = ch.Id }, ch);
            }
            return BadRequest($"Duplicate ID, Could not create character with ID {ch.Id}");

        }


        [HttpDelete("{id}", Name = "DeleteCharacterByID")]
        public ActionResult DeleteCharacter(int id)
        {
            var result = _characterStore.RemoveCharacter(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}", Name = "UpdateCharacter")]
        public ActionResult<Character> UpdateCharacter(int id, Character newCharacter)
        {
            var result = _characterStore.UpdateCharacter(id, newCharacter);

            if (result)
            {
                return Ok(newCharacter);
            }
            return NotFound();
        }
    }
}

