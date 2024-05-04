using Online_Recipes_Domain.Models;

namespace Online_Recipes_Domain.DTOs
{
    public class RecipeDto : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Difficulty Difficulty { get; set; }

        public int CookingTime { get; set; }

        public string? Photo { get; set; }
    }
}
