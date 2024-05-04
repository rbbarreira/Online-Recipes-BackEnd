using System.Text.Json.Serialization;

namespace Online_Recipes_Domain.Models
{
    public class Ingredient_Quantity : Entity
    {
        public int Quantity { get; set; }

        public Measure Measure { get; set; }

        [JsonIgnore]
        public ICollection<Ingredient>? Ingredients { get; set; }

        [JsonIgnore]
        public ICollection<Recipe>? Recipes { get; set; }
    }

    public enum Measure
    {
        kg,
        g,
        ml,
        pc,
        un
    }
}
