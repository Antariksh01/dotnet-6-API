using AutoMapper;
using dotnet_6_API.Data;
using dotnet_6_API.DTO;
using Microsoft.EntityFrameworkCore;

namespace dotnet_6_API.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
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
            _context.Characters.Add(characterData);
            await _context.SaveChangesAsync();
            serviceResponse.data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var dbcharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetCharacterDTO>(dbcharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDTO>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            response.data = dbCharacters.Select(c=> _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }
    }
}
