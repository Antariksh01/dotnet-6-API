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
        public ActionResult<ServiceResponse<List<GetCharacterDTO>>> GetCharacters()
        {
            characters = _characterService.GetCharacters();
            return Ok(characters);
        }

        [HttpGet("GetCharacterById/{Id}")]
        public ActionResult<ServiceResponse<GetCharacterDTO>> GetCharacterById(int Id)
        {
            ServiceResponse<GetCharacterDTO> character = _characterService.GetCharacterById(Id);  

            return Ok(character);
        }

        [HttpPost("AddCharacter")]
        public ActionResult<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO character)
        {
            characters = _characterService.AddCharacter(character);
            return Ok(characters);
        }
    }
}
