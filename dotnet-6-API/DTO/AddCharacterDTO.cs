namespace dotnet_6_API.DTO
{
    public class AddCharacterDTO
    {
        public string Name { get; set; } = "Krishna";
        public int Strength { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Stamina { get; set; } = 10;
        public int HitPoints { get; set; } = 10;
        public Category Category { get; set; } = Category.God;
    }
}
