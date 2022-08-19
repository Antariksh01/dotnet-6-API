namespace dotnet_6_API.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character()
            {
                Id = 1,
                Name = "Bhishm"
            }
        };
        public ServiceResponse<List<Character>> AddCharacter(Character character)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();           
            characters.Add(character);  
            serviceResponse.data = characters;
            return serviceResponse;
            throw new NotImplementedException();
        }

        public ServiceResponse<Character> GetCharacterById(int Id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            Character character = characters.FirstOrDefault(c => c.Id == Id);
            serviceResponse.data = character;
            return serviceResponse;
            throw new NotImplementedException();
        }

        public ServiceResponse<List<Character>> GetCharacters()
        {
            var response = new ServiceResponse<List<Character>>();
            response.data = characters;
            return response;
            throw new NotImplementedException();
        }
    }
}
