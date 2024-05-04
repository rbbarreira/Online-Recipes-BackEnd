using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Online_Recipes_Domain.Models;

namespace Online_Recipes_Data.Seeds
{
    public class Ingredient_QuantitySeed : IEntityTypeConfiguration<Ingredient_Quantity>
    {
        public void Configure(EntityTypeBuilder<Ingredient_Quantity> builder)
        {
            builder
                .HasData
                ( new Ingredient_Quantity { Id = 1, Quantity = 1, Measure = Measure.un },
                  new Ingredient_Quantity { Id = 2, Quantity = 1, Measure = Measure.pc },
                  new Ingredient_Quantity { Id = 3, Quantity = 1, Measure = Measure.kg },
                  new Ingredient_Quantity { Id = 4, Quantity = 2, Measure = Measure.un },
                  new Ingredient_Quantity { Id = 5, Quantity = 2, Measure = Measure.pc },
                  new Ingredient_Quantity { Id = 6, Quantity = 4, Measure = Measure.pc },
                  new Ingredient_Quantity { Id = 7, Quantity = 100, Measure = Measure.ml },
                  new Ingredient_Quantity { Id = 8, Quantity = 100, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 9, Quantity = 150, Measure = Measure.ml },
                  new Ingredient_Quantity { Id = 10, Quantity = 150, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 11, Quantity = 200, Measure = Measure.ml },
                  new Ingredient_Quantity { Id = 12, Quantity = 200, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 13, Quantity = 250, Measure = Measure.ml },
                  new Ingredient_Quantity { Id = 14, Quantity = 250, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 15, Quantity = 300, Measure = Measure.ml },
                  new Ingredient_Quantity { Id = 16, Quantity = 300, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 17, Quantity = 400, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 18, Quantity = 500, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 19, Quantity = 600, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 20, Quantity = 800, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 21, Quantity = 700, Measure = Measure.g },
                  new Ingredient_Quantity { Id = 22, Quantity = 6, Measure = Measure.un },
                  new Ingredient_Quantity { Id = 23, Quantity = 12, Measure = Measure.pc },
                  new Ingredient_Quantity { Id = 24, Quantity = 40, Measure = Measure.g });
        }
    }
}
