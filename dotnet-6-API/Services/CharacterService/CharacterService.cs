using AutoMapper;
using dotnet_6_API.DTO;

namespace dotnet_6_API.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character()
            {
                Id = 1,
                Name = "Bhishm"
            }
        };
        
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO character)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>(); 
            Character characterData = _mapper.Map<Character>(character);
            characterData.Id = characters.Max(c => c.Id) + 1;
            characters.Add(characterData);
            serviceResponse.data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var character = characters.FirstOrDefault(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetCharacterDTO>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDTO>>();
            response.data = characters.Select(c=> _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
            throw new NotImplementedException();
        }
    }
}
