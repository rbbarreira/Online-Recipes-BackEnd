using System.Text.Json.Serialization;

namespace Online_Recipes_Domain.Models
{
    public class Comment : Entity
    {
        public string UsersComment { get; set; }

        [JsonIgnore]
        public Recipe? Recipe { get; set; }
    }
}
