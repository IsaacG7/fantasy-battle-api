using FantasyBattleAPI.Models;

namespace FantasyBattleAPI.Services
{
    public class CharacterStore
    {
        private List<Character> _characters = new List<Character>();

        public bool AddCharacter(Character c)
        {
            foreach (var character in _characters)
            {
                if (character.Id == c.Id)
                {
                    return false;
                }
            }
            _characters.Add(c);
            return true;
        }

        public bool RemoveCharacter(int id)
        {
            foreach (var character in _characters)
            {
                if (character.Id == id)
                {
                    _characters.Remove(character);
                    return true;
                }
            }
            return false;
        }

        public List<Character> GetAllCharacters()
        {
            List<Character> clist = new List<Character>(_characters);
            return clist;
        }

        public Character GetCharacterById(int id)
        {
            foreach (var character in _characters)
            {
                if (character.Id == id)
                {
                    return character;
                }
            }
            return null;
        }
    }
}
