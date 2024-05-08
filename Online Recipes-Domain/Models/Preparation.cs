using System.Text.Json.Serialization;

namespace Online_Recipes_Domain.Models
{
    public class Preparation : Entity
    {
        public string[] Steps { get; set; }

        [JsonIgnore]
        public ICollection<Recipe> ?Recipes { get; set; }
    }
}
