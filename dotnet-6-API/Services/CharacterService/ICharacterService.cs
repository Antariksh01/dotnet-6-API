using dotnet_6_API.DTO;

namespace dotnet_6_API.Services.CharacterService
{
    public interface ICharacterService
    {
        public ServiceResponse<List<GetCharacterDTO>> GetCharacters();
        public ServiceResponse<GetCharacterDTO> GetCharacterById(int Id);
        public ServiceResponse<List<GetCharacterDTO>> AddCharacter(AddCharacterDTO character);
    }
}
