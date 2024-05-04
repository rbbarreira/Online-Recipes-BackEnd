using System.Text.Json.Serialization;

namespace Online_Recipes_Domain.Models
{
    public class Recipe : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Difficulty Difficulty { get; set; }

        public int CookingTime { get; set; }

        public string? Photo { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime ModifiedDate { get; set; } = DateTime.Now;


        // EF Relation

        [JsonIgnore]
        //public ICollection<User>? Users { get; set; }

        public ICollection<Ingredient>? Ingredients { get; set; }

        public ICollection<Ingredient_Quantity>? Ingredient_Quantities { get; set; }

        public ICollection<Category>? Categories { get; set; }

        public ICollection<Preparation>? Preparations { get; set; }

        public ICollection<Rating>? Ratings { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }

    public enum Difficulty
    {
        easy,
        medium,
        hard
    }
}
