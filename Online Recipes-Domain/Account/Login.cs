using System.ComponentModel.DataAnnotations;

namespace Online_Recipes_Domain.Account
{
    // Modelo usado só para o LOGIN
    public class Login
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
