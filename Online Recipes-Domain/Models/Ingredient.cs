using System.Text.Json.Serialization;

namespace Online_Recipes_Domain.Models
{
    public class Ingredient : Entity
    {
        public string Product { get; set; }

        [JsonIgnore]
        public ICollection<Recipe>? Recipes { get; set; }

        public ICollection<Ingredient_Quantity>? Ingredient_Quantities { get; set; }
    }
}
