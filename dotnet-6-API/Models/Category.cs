using System.Text.Json.Serialization;

namespace dotnet_6_API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Category
    {
        God = 0,
        King = 1,
        Warrior = 2
    }
}
