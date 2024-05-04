using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Online_Recipes_Data.Context;
using Online_Recipes_Domain.Account;
using Online_Recipes_Repository.Repo_Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Online_Recipes_Repository.Repo_Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationContext applicationContext, IConfiguration configuration) : base(applicationContext)
        {
            _configuration = configuration;
            _context = applicationContext;
        }

        //Verifica Email
        public async Task<bool> EmailExist(string? email)
        {
            return await _dbSet.AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }

        //Verifica UserName
        public async Task<bool> UsernameExist(string? username)
        {
            return await _dbSet.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbSet.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        //Primeiro utilizador é Admin, os seguintes são User
        public async Task<User> Add(User user)
        {
            var exist = _dbSet.FirstOrDefault(user => user.Id == user.Id);

            if (exist == null)
            {
                user.Role = Role.Admin;
            }
            else
            {
                user.Role = Role.User;
            }

            _dbSet.Add(user);
            await SaveChanges();
            return user;
        }

        // Autentica o usuário verificando Email e a Password
        public async Task<bool> Authenticate(string email, string password)
        {
            var user = await _dbSet.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();

            if (user == null)
            {
                return false;
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int x = 0; x < computedHash.Length; x++)
            {
                if (computedHash[x] != user.PasswordHash[x])
                {
                    return false;
                }
            }

            return true;
        }

        //Cria o Token após o LOGIN para aceder a conteudo Autorizado
        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
