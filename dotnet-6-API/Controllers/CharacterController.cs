using dotnet_6_API.DTO;
using dotnet_6_API.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_6_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;
        private ServiceResponse<List<GetCharacterDTO>> characters;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }       

        [HttpGet("GetCharacters")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> GetCharacters()
        {
            characters = await _characterService.GetCharacters();
            return Ok(characters);
        }

        [HttpGet("GetCharacterById/{Id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetCharacterById(int Id)
        {
            ServiceResponse<GetCharacterDTO> character = await _characterService.GetCharacterById(Id);  

            return Ok(character);
        }

        [HttpPost("AddCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> AddCharacter(AddCharacterDTO character)
        {
            characters = await _characterService.AddCharacter(character);
            return Ok(characters);
        }
    }
}
