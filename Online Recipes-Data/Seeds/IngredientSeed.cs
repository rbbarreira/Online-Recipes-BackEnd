using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Online_Recipes_Domain.Models;

namespace Online_Recipes_Data.Seeds
{
    public class IngredientSeed : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder
                .HasData
                ( new Ingredient { Id = 1, Product = "Pork" }, new Ingredient { Id = 2, Product = "Pepper paste" },
                  new Ingredient { Id = 3, Product = "Blonde" }, new Ingredient { Id = 4, Product = "Orange" },
                  new Ingredient { Id = 5, Product = "Brunette" }, new Ingredient { Id = 6, Product = "onion" },
                  new Ingredient { Id = 7, Product = "Olive oil" }, new Ingredient { Id = 8, Product = "Shall" },
                  new Ingredient { Id = 9, Product = "Curget" }, new Ingredient { Id = 10, Product = "Mushroom" },
                  new Ingredient { Id = 11, Product = "Pepper" }, new Ingredient { Id = 12, Product = "Sweet chili" },
                  new Ingredient { Id = 13, Product = "Dried thyme" }, new Ingredient { Id = 14, Product = "chickpea" },
                  new Ingredient { Id = 15, Product = "salt" }, new Ingredient { Id = 16, Product = "veal" },
                  new Ingredient { Id = 17, Product = "bacon" }, new Ingredient { Id = 18, Product = "meat sausage" },
                  new Ingredient { Id = 19, Product = "spare ribs" }, new Ingredient { Id = 20, Product = "chicken" },
                  new Ingredient { Id = 21, Product = "potato" }, new Ingredient { Id = 22, Product = "carrot" },
                  new Ingredient { Id = 23, Product = "savoy cabbage" }, new Ingredient { Id = 24, Product = "scratched pasta" },
                  new Ingredient { Id = 25, Product = "cumin" }, new Ingredient { Id = 26, Product = "garlic" },
                  new Ingredient { Id = 27, Product = "water" }, new Ingredient { Id = 28, Product = "yellow corn flour" },
                  new Ingredient { Id = 29, Product = "green soup" }, new Ingredient { Id = 30, Product = "oil" },
                  new Ingredient { Id = 31, Product = "green laurel sticks" }, new Ingredient { Id = 32, Product = "fillet meat in cubes" },
                  new Ingredient { Id = 33, Product = "ling" }, new Ingredient { Id = 34, Product = "shrimp" },
                  new Ingredient { Id = 35, Product = "tomato" }, new Ingredient { Id = 36, Product = "leek" },
                  new Ingredient { Id = 37, Product = "noodle dough" }, new Ingredient { Id = 38, Product = "coriander" },
                  new Ingredient { Id = 39, Product = "parsley" }, new Ingredient { Id = 40, Product = "cod fish" },
                  new Ingredient { Id = 41, Product = "eggs" }, new Ingredient { Id = 42, Product = "black olive" },
                  new Ingredient { Id = 43, Product = "sea bream" }, new Ingredient { Id = 44, Product = "pepper" },
                  new Ingredient { Id = 45, Product = "fennel" }, new Ingredient { Id = 46, Product = "pear" },
                  new Ingredient { Id = 47, Product = "butter" }, new Ingredient { Id = 48, Product = "white wine" },
                  new Ingredient { Id = 49, Product = "risotto rice" }, new Ingredient { Id = 50, Product = "broth" },
                  new Ingredient { Id = 51, Product = "cheese" }, new Ingredient { Id = 52, Product = "portobello mushroom" },
                  new Ingredient { Id = 53, Product = "pumpkin" }, new Ingredient { Id = 54, Product = "asparagus" },
                  new Ingredient { Id = 55, Product = "almond" }, new Ingredient { Id = 56, Product = "rice" },
                  new Ingredient { Id = 57, Product = "bread" });

            builder
                .HasMany(r => r.Ingredient_Quantities)
                .WithMany(c => c.Ingredients)
                .UsingEntity<Dictionary<string, object>>(
                    "Ingredient_QuantityRecipeIngredient",
                    r => r.HasOne<Ingredient_Quantity>().WithMany().HasForeignKey("Ingredient_QuantitiesId"),
                    l => l.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientsId"),
                    je =>
                    {
                        je.HasKey("IngredientsId", "Ingredient_QuantitiesId");
                        je.HasData( new { IngredientsId = 1, Ingredient_QuantitiesId = 19 }, new { IngredientsId = 2, Ingredient_QuantitiesId = 5 },
                                    new { IngredientsId = 3, Ingredient_QuantitiesId = 1 }, new { IngredientsId = 4, Ingredient_QuantitiesId = 5 },
                                    new { IngredientsId = 5, Ingredient_QuantitiesId = 20 }, new { IngredientsId = 6, Ingredient_QuantitiesId = 5 },
                                    new { IngredientsId = 7, Ingredient_QuantitiesId = 7 }, new { IngredientsId = 8, Ingredient_QuantitiesId = 1 },
                                    new { IngredientsId = 9, Ingredient_QuantitiesId = 16 }, new { IngredientsId = 10, Ingredient_QuantitiesId = 16 },
                                    new { IngredientsId = 11, Ingredient_QuantitiesId = 1 }, new { IngredientsId = 12, Ingredient_QuantitiesId = 1 },
                                    new { IngredientsId = 13, Ingredient_QuantitiesId = 1 }, new { IngredientsId = 14, Ingredient_QuantitiesId = 18 },
                                    new { IngredientsId = 15, Ingredient_QuantitiesId = 1 }, new { IngredientsId = 16, Ingredient_QuantitiesId = 18 },
                                    new { IngredientsId = 17, Ingredient_QuantitiesId = 12 }, new { IngredientsId = 18, Ingredient_QuantitiesId = 12 },
                                    new { IngredientsId = 19, Ingredient_QuantitiesId = 18 }, new { IngredientsId = 20, Ingredient_QuantitiesId = 17 },
                                    new { IngredientsId = 21, Ingredient_QuantitiesId = 18 }, new { IngredientsId = 22, Ingredient_QuantitiesId = 14 },
                                    new { IngredientsId = 23, Ingredient_QuantitiesId = 3 }, new { IngredientsId = 24, Ingredient_QuantitiesId = 18 },
                                    new { IngredientsId = 25, Ingredient_QuantitiesId = 1 }, new { IngredientsId = 26, Ingredient_QuantitiesId = 6 },
                                    new { IngredientsId = 27, Ingredient_QuantitiesId = 13 }, new { IngredientsId = 28, Ingredient_QuantitiesId = 12 },
                                    new { IngredientsId = 29, Ingredient_QuantitiesId = 10 }, new { IngredientsId = 30, Ingredient_QuantitiesId = 15 },
                                    new { IngredientsId = 31, Ingredient_QuantitiesId = 6 }, new { IngredientsId = 32, Ingredient_QuantitiesId = 3 },
                                    new { IngredientsId = 33, Ingredient_QuantitiesId = 21 }, new { IngredientsId = 34, Ingredient_QuantitiesId = 18 },
                                    new { IngredientsId = 35, Ingredient_QuantitiesId = 12 }, new { IngredientsId = 36, Ingredient_QuantitiesId = 8 },
                                    new { IngredientsId = 37, Ingredient_QuantitiesId = 14 }, new { IngredientsId = 38, Ingredient_QuantitiesId = 1 },
                                    new { IngredientsId = 39, Ingredient_QuantitiesId = 1 }, new { IngredientsId = 40, Ingredient_QuantitiesId = 5 },
                                    new { IngredientsId = 41, Ingredient_QuantitiesId = 22 }, new { IngredientsId = 42, Ingredient_QuantitiesId = 23 },
                                    new { IngredientsId = 43, Ingredient_QuantitiesId = 18 }, new { IngredientsId = 44, Ingredient_QuantitiesId = 1 },
                                    new { IngredientsId = 45, Ingredient_QuantitiesId = 8 }, new { IngredientsId = 46, Ingredient_QuantitiesId = 16 },
                                    new { IngredientsId = 47, Ingredient_QuantitiesId = 14 }, new { IngredientsId = 48, Ingredient_QuantitiesId = 7 },
                                    new { IngredientsId = 49, Ingredient_QuantitiesId = 16 }, new { IngredientsId = 50, Ingredient_QuantitiesId = 3 },
                                    new { IngredientsId = 51, Ingredient_QuantitiesId = 14 }, new { IngredientsId = 52, Ingredient_QuantitiesId = 21 },
                                    new { IngredientsId = 53, Ingredient_QuantitiesId = 19 }, new { IngredientsId = 54, Ingredient_QuantitiesId = 12 },
                                    new { IngredientsId = 55, Ingredient_QuantitiesId = 24 }, new { IngredientsId = 56, Ingredient_QuantitiesId = 14 },
                                    new { IngredientsId = 57, Ingredient_QuantitiesId = 12 });
                    });

        }
    }
}
