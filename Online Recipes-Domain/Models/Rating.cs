using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Online_Recipes_Domain.Models
{
    public class Rating : Entity
    {
        [RegularExpression("[0-5]")]
        public int Star { get; set; } = 0;

        [JsonIgnore]
        public ICollection<Recipe> ?Recipes { get; set; }
    }
}
