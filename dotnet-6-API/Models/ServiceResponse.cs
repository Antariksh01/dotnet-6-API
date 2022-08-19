namespace dotnet_6_API.Models
{
    public class ServiceResponse<T>
    {
        public T? data { get; set; }
        public Boolean Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
