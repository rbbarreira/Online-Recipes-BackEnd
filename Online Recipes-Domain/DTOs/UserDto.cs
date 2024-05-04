using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Online_Recipes_Domain.Models;

namespace Online_Recipes_Domain.DTOs
{
    public class UserDto : Entity
    {
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [NotMapped]
        public string Password { get; set; } = string.Empty;
    }
}
