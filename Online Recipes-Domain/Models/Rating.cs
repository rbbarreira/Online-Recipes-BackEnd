using System.Text.Json.Serialization;

namespace Online_Recipes_Domain.Models
{
    public class Rating : Entity
    {        
        public int Star { get; set; } 

        [JsonIgnore]
        public ICollection<Recipe> ?Recipes { get; set; }
    }
}
