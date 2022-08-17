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
        public List<Character> AddCharacter(Character character)
        {
            characters.Add(character);  
            return characters;
            throw new NotImplementedException();
        }

        public Character GetCharacterById(int Id)
        {
            Character character = characters.FirstOrDefault(c => c.Id == Id);
            return character;
            throw new NotImplementedException();
        }

        public List<Character> GetCharacters()
        {
            return characters;
            throw new NotImplementedException();
        }
    }
}
