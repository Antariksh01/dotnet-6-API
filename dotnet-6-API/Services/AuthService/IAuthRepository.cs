namespace dotnet_6_API.Services.AuthService
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> RegisterUser(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
