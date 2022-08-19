namespace dotnet_6_API.Services.CharacterService
{
    public interface ICharacterService
    {
        public ServiceResponse<List<Character>> GetCharacters();
        public ServiceResponse<Character> GetCharacterById(int Id);
        public ServiceResponse<List<Character>> AddCharacter(Character character);
    }
}
