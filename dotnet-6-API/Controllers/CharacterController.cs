using dotnet_6_API.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_6_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;
        private ServiceResponse<List<Character>> characters;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }       

        [HttpGet("GetCharacters")]
        public ActionResult<ServiceResponse<List<Character>>> GetCharacters()
        {
            characters = _characterService.GetCharacters();
            return Ok(characters);
        }

        [HttpGet("GetCharacterById/{Id}")]
        public ActionResult<ServiceResponse<Character>> GetCharacterById(int Id)
        {
            ServiceResponse<Character> character = _characterService.GetCharacterById(Id);  

            return Ok(character);
        }

        [HttpPost("AddCharacter")]
        public ActionResult<ServiceResponse<List<Character>>> AddCharacter(Character character)
        {
            characters = _characterService.AddCharacter(character);
            return Ok(characters);
        }
    }
}
