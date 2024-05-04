using AutoMapper;
using Online_Recipes_Domain.Account;
using Online_Recipes_Domain.DTOs;
using Online_Recipes_Repository.Repo_Interfaces;
using Online_Recipes_Service.Service_Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Online_Recipes_Service.Service_Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<UserDto> Add(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            // Cria Password criando ligação ente passwordHash e passwordSalt
            if (userDto.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
                byte[] passwordSalt = hmac.Key;

                user.CombinePassword(passwordHash, passwordSalt);
            }

            var userResult = await _userRepository.Add(user);

            return _mapper.Map<UserDto>(userResult);
        }

        public async Task<User> Update(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<User> RemoveById(int id)
        {
            return await _userRepository.RemoveById(id);
        }

        public async Task<bool> Delete(User user)
        {
            await _userRepository.Delete(user);

            return true;
        }

        public async Task<bool> EmailExist(string? email)
        {
            return await _userRepository.EmailExist(email);
        }

        public async Task<bool> UsernameExist(string? username)
        {
            return await _userRepository.UsernameExist(username);
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            return await _userRepository.Authenticate(email, password);
        }

        public string GenerateToken(User user)
        {
            return _userRepository.GenerateToken(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }
    }
}
