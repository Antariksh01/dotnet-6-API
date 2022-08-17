using Microsoft.AspNetCore.Mvc;

namespace dotnet_6_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        Character characters = new Character();

        [HttpGet("GetCharacters")]
        public ActionResult GetCharacters()
        {
            return Ok(characters);
        }
    }
}
