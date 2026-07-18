using FantasyBattleAPI.Data;
using FantasyBattleAPI.Models;
using Microsoft.EntityFrameworkCore;
using FantasyBattleAPI.DTOs;
using System.Text.Json;



namespace FantasyBattleAPI.Services
{
    public class CharacterServiceAgent
    {
        private AppDbContext _context;
        private ILogger<CharacterServiceAgent> _logger;
        public CharacterServiceAgent(AppDbContext context, ILogger<CharacterServiceAgent> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool AddCharacter(Character c)
        {

            try
            {
                _context.Characters.Add(c);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
                _logger.LogError("Failed to update database with new character");
                return false;
            }
            return true;
        }

        public bool RemoveCharacter(int id)
        {

            var character = _context.Characters.FirstOrDefault(c => c.Id == id);
            if (character == null)
            {
                return false;
            }
            _context.Characters.Remove(character);
            _context.SaveChanges();

            return true;
        }

        public List<Character> GetAllCharacters()
        {
            var clist = _context.Characters.ToList();
            return clist;
        }

        public Character GetCharacterById(int id)
        {
            var character = _context.Characters.FirstOrDefault(c => c.Id == id);
            return character;
        }

        public bool UpdateCharacter(int id, PatchCharacterDto patchCharacter)
        {

            var character = _context.Characters.FirstOrDefault((c) => c.Id == id);
            if (character == null)
            {
                return false;
            }
            else
            {
                character.Hp = patchCharacter.Hp ?? character.Hp;
                character.Level = patchCharacter.Level ?? character.Level;
                character.Race = patchCharacter.Race ?? character.Race;
                character.Attack = patchCharacter.Attack ?? character.Attack;
                character.Defense = patchCharacter.Defense ?? character.Defense;
                character.Name = patchCharacter.Name ?? character.Name;
                character.CharacterClass = patchCharacter.CharacterClass ?? character.CharacterClass;
                _context.SaveChanges();
                return true;
            }
        }
    }
}




