namespace dotnet_6_API.Services.CharacterService
{
    public interface ICharacterService
    {
        public List<Character> GetCharacters();
        public Character GetCharacterById(int Id);
        public List<Character> AddCharacter(Character character);
    }
}
