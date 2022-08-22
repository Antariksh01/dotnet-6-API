using dotnet_6_API.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet_6_API.Services.AuthService
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(c=>c.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Password is wrong";
            }
            else
                response.data = user.Id.ToString();

            return response;
        }

        public async Task<ServiceResponse<int>> RegisterUser(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExist(user.Username))
            {
                response.Success = false;
                response.Message = "User already exist";
                return response;
            }
            CreatePassword(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();          
            response.data = user.Id;
            return response;
        }

        public async Task<bool> UserExist(string username)
        {
            if(await _context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            
            return false;
        }

        public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));  
            }
        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) { 
               var computeHash =  hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
    }
}
