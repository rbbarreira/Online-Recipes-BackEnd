using Online_Recipes_Domain.Account;

namespace Online_Recipes_Repository.Repo_Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Add(User user);

        Task<bool> EmailExist(string? email);

        Task<bool> UsernameExist(string? username);

        Task<bool> Authenticate(string email, string password);

        public Task<User> GetUserByEmail(string email);

        public string GenerateToken(User user);
    }
}
