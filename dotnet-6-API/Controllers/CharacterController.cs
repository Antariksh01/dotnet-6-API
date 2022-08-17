using Microsoft.AspNetCore.Mvc;

namespace dotnet_6_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character(){ Id=1,Name="Bhishm",Strength=10,Stamina=10,Category=Category.Warrior},
        };

        [HttpGet("GetCharacters")]
        public ActionResult<List<Character>> GetCharacters()
        {
            return Ok(characters);
        }

        [HttpGet("GetCharacterById/{Id}")]
        public ActionResult<Character> GetCharacterById(int Id)
        {
            Character character = characters.FirstOrDefault(c => c.Id == Id);

            return Ok(character);
        }
    }
}
