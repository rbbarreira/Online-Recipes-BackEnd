using System.Text.Json.Serialization;

namespace Online_Recipes_Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Recipe>? Recipes { get; set; }
    }
}
