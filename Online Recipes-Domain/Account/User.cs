using Online_Recipes_Domain.Models;
using System.Text.Json.Serialization;

namespace Online_Recipes_Domain.Account
{
    public class User : Entity
    {
        public string ?UserName { get; set; } = string.Empty;

        public string ?Email { get; set; } = string.Empty;

        [JsonIgnore]
        public byte[] ?PasswordHash { get; set; }

        [JsonIgnore]
        public byte[] ?PasswordSalt { get; set; }

        public string ?Role { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Recipe>? Recipes { get; set; }

        // Metodo para combinar e criar Password
        public void CombinePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
