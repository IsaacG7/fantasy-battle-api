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

        public bool UpdateCharacter(int id, Character newCharacter)
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                // If the new chatacter id matches the current one we are on
                // and its not the one we intend to replace then there will be a duplicate
                // so return false 
                if (newCharacter.Id == _characters[i].Id && id != _characters[i].Id)
                {
                    return false;
                }
            }
            for (int j = 0; j < _characters.Count; j++)
            {
     

                if (_characters[j].Id == id)
                {
                    _characters[j] = newCharacter;
                    return true;
                }
            }
            return false;
        }
    }
}




