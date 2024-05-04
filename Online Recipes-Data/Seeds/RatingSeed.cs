using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Online_Recipes_Domain.Models;

namespace Online_Recipes_Data.Seeds
{
    public class RatingSeed : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder
               .HasData
               ( new Rating { Id = 1, Star = 4 },
                 new Rating { Id = 2, Star = 3 },
                 new Rating { Id = 3, Star = 5 });
        }
    }
}
