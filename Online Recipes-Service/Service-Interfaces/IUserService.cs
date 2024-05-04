using Online_Recipes_Domain.Account;
using Online_Recipes_Domain.DTOs;

namespace Online_Recipes_Service.Service_Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int id);

        Task<UserDto> Add(UserDto user);

        Task<User> Update(User user);

        Task<User> RemoveById(int id);

        Task<bool> EmailExist(string? email);

        Task<bool> UsernameExist(string? username);

        Task<bool> Authenticate(string email, string password);

        Task<User> GetUserByEmail(string email);

        public string GenerateToken(User user);
    }
}
