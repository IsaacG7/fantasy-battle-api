namespace FantasyBattleAPI.DTOs
{
    public class PatchCharacterDto
    {
        public int? Level { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public int? Hp { get; set; }
        public string? Name { get; set; }
        public string? Race { get; set; }
        public string? CharacterClass { get; set; }
    }
}
