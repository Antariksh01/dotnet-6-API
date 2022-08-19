using dotnet_6_API.DTO;

namespace dotnet_6_API.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<ServiceResponse<List<GetCharacterDTO>>> GetCharacters();
        public Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int Id);
        public Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO character);
    }
}
