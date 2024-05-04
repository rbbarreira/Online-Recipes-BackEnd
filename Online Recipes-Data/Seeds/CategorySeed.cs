using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Online_Recipes_Domain.Models;

namespace Online_Recipes_Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
               .HasData
               ( new Category { Id = 1, Name = "Meat" }, new Category { Id = 2, Name = "Fish" },
                 new Category { Id = 3, Name = "Vegetarian" });
        }
    }
}
