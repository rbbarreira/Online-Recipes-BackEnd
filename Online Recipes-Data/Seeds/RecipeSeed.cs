using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Online_Recipes_Domain.Models;

namespace Online_Recipes_Data.Seeds
{
    public class RecipeSeed : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
               .HasData
               (
               new Recipe
               {
                   Id = 1,
                   Name = "Pork rojões with chestnutts",
                   Description = "Discover the authenticity of our pork Rojões with chestnuts. Enjoy irresistible flavors and gastronomic tradition, inspired by the richness of the Portuguese Mediterranean Diet!",
                   Difficulty = Difficulty.easy,
                   CookingTime = 90,
                   Photo = "/assets/Pork rojões with chestnuts.jpg"
               },
               new Recipe
               {
                   Id = 2,
                   Name = "Viseu`s Ranch",
                   Description = "In Viseu, to moralize the troops who were going through difficult times, instructions were given to reinforce their diet. From the barracks to the table, Viseu-style ranch was born, a dish that combines chickpeas, potatoes, vegetables, thick pasta and pork, veal and chicken.",
                   Difficulty = Difficulty.medium,
                   CookingTime = 30,
                   Photo = "/assets/Viseu Ranch.jpg"
               },
               new Recipe
               {
                   Id = 3,
                   Name = "Madeiran kebabs with fried corn",
                   Description = "Probably the best-known Madeiran dish outside the archipelago. Kebabs are usually accompanied with fried corn, a snack made with cooked corn flour, then cut into cubes and fried, which is almost as good as the kebab itself.",
                   Difficulty = Difficulty.medium,
                   CookingTime = 60,
                   Photo = "/assets/Madeiran kebabs with fried corn.jpg"
               },
               new Recipe
               {
                   Id = 4,
                   Name = "Fish pasta",
                   Description = "Fish pasta is a main course meal, but can be served as a starter for a lighter second course.",
                   Difficulty = Difficulty.easy,
                   CookingTime = 60,
                   Photo = "/assets/Fish pasta.jpg"
               },
               new Recipe
               {
                   Id = 5,
                   Name = "Cod fish à Brás",
                   Description = "With cod, eggs and potatoes, this is one of the most popular recipes among the Portuguese. Easy and quick to make, you can easily adapt the method and try it with fish, shredded chicken or even leek.",
                   Difficulty = Difficulty.medium,
                   CookingTime = 45,
                   Photo = "/assets/Cod fish à Brás.jpg"
               },
               new Recipe
               {
                   Id = 6,
                   Name = "Sea bream fillets with orange sauce",
                   Description = "Fruits such as orange, lemon or tangerine are popular in countless recipes. Prepare these sea bream fillets with orange sauce and make the most of the color and sweet flavor in a quick and healthy meal.",
                   Difficulty = Difficulty.medium,
                   CookingTime = 20,
                   Photo = "/assets/Sea bream fillets with orange sauce.jpg"
               },
               new Recipe
               {
                   Id = 7,
                   Name = "Azeitão Cheese and pear risotto",
                   Description = "This risotto combines the traditional flavor of Azeitão cheese and the sweetness of pear, representing the gastronomic authenticity of Portugal, with Italian influences.",
                   Difficulty = Difficulty.easy,
                   CookingTime = 30,
                   Photo = "/assets/Azeitão Cheese and pear risotto.jpg"
               },
               new Recipe
               {
                   Id = 8,
                   Name = "Stuffed Portobello Mushrooms",
                   Description = "Try stuffed Portobello mushrooms for a balanced meal. Rich in nutrients and vegetable protein, they are ideal for vegetarian diets.",
                   Difficulty = Difficulty.hard,
                   CookingTime = 60,
                   Photo = "/assets/Stuffed Portobello Mushrooms.jpg"
               },
               new Recipe
               {
                   Id = 9,
                   Name = "Açorda with coriander and egg",
                   Description = "Use leftover carcasses (papos-secos) or mixed bread and prepare a delicious bread soup with coriander and egg. A typical Portuguese dish, vegetarian and without food waste.",
                   Difficulty = Difficulty.easy,
                   CookingTime = 25,
                   Photo = "/assets/Açorda with coriander and egg.jpg"
               });

            builder
                .HasMany(r => r.Categories)
                .WithMany(c => c.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryRecipe",
                    r => r.HasOne<Category>().WithMany().HasForeignKey("CategoriesId"),
                    l => l.HasOne<Recipe>().WithMany().HasForeignKey("RecipesId"),
                    je =>
                    {
                        je.HasKey("RecipesId", "CategoriesId");
                        je.HasData( new { RecipesId = 1, CategoriesId = 1 }, new { RecipesId = 2, CategoriesId = 1 },
                                    new { RecipesId = 3, CategoriesId = 1 }, new { RecipesId = 4, CategoriesId = 2 },
                                    new { RecipesId = 5, CategoriesId = 2 }, new { RecipesId = 6, CategoriesId = 2 },
                                    new { RecipesId = 7, CategoriesId = 3 }, new { RecipesId = 8, CategoriesId = 3 },
                                    new { RecipesId = 9, CategoriesId = 3 });
                    });

            builder
                .HasMany(r => r.Preparations)
                .WithMany(c => c.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "PreparationRecipe",
                    r => r.HasOne<Preparation>().WithMany().HasForeignKey("PreparationsId"),
                    l => l.HasOne<Recipe>().WithMany().HasForeignKey("RecipesId"),
                    je =>
                    {
                        je.HasKey("RecipesId", "PreparationsId");
                        je.HasData( new { RecipesId = 1, PreparationsId = 1 }, new { RecipesId = 2, PreparationsId = 2 },
                                    new { RecipesId = 3, PreparationsId = 3 }, new { RecipesId = 4, PreparationsId = 4 },
                                    new { RecipesId = 5, PreparationsId = 5 }, new { RecipesId = 6, PreparationsId = 6 },
                                    new { RecipesId = 7, PreparationsId = 7 }, new { RecipesId = 8, PreparationsId = 8 },
                                    new { RecipesId = 9, PreparationsId = 9 });
                    });

            builder
                .HasMany(r => r.Ratings)
                .WithMany(c => c.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "RatingRecipe",
                    r => r.HasOne<Rating>().WithMany().HasForeignKey("RatingsId"),
                    l => l.HasOne<Recipe>().WithMany().HasForeignKey("RecipesId"),
                    je =>
                    {
                        je.HasKey("RecipesId", "RatingsId");
                        je.HasData( new { RecipesId = 1, RatingsId = 1 }, new { RecipesId = 2, RatingsId = 2 },
                                    new { RecipesId = 3, RatingsId = 3 }, new { RecipesId = 4, RatingsId = 1 },
                                    new { RecipesId = 5, RatingsId = 2 }, new { RecipesId = 6, RatingsId = 3 },
                                    new { RecipesId = 7, RatingsId = 1 }, new { RecipesId = 8, RatingsId = 2 },
                                    new { RecipesId = 9, RatingsId = 3 });
                    });

            builder
                .HasMany(r => r.Ingredients)
                .WithMany(i => i.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "IngredientRecipe",
                    r => r.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientsId"),
                    l => l.HasOne<Recipe>().WithMany().HasForeignKey("RecipesId"),
                    je =>
                    {
                        je.HasKey("RecipesId", "IngredientsId");
                        je.HasData( new { RecipesId = 1, IngredientsId = 1 }, new { RecipesId = 1, IngredientsId = 2 }, new { RecipesId = 1, IngredientsId = 3 }, new { RecipesId = 1, IngredientsId = 4 },
                                    new { RecipesId = 1, IngredientsId = 5 }, new { RecipesId = 1, IngredientsId = 6 }, new { RecipesId = 1, IngredientsId = 7 }, new { RecipesId = 1, IngredientsId = 8 },
                                    new { RecipesId = 1, IngredientsId = 9 }, new { RecipesId = 1, IngredientsId = 10 }, new { RecipesId = 1, IngredientsId = 11 }, new { RecipesId = 1, IngredientsId = 12 },
                                    new { RecipesId = 1, IngredientsId = 13 }, new { RecipesId = 2, IngredientsId = 14 }, new { RecipesId = 2, IngredientsId = 15 }, new { RecipesId = 2, IngredientsId = 16 },
                                    new { RecipesId = 2, IngredientsId = 17 }, new { RecipesId = 2, IngredientsId = 18 }, new { RecipesId = 2, IngredientsId = 19 }, new { RecipesId = 2, IngredientsId = 20 },
                                    new { RecipesId = 2, IngredientsId = 21 }, new { RecipesId = 2, IngredientsId = 22 }, new { RecipesId = 2, IngredientsId = 23 }, new { RecipesId = 2, IngredientsId = 24 },
                                    new { RecipesId = 2, IngredientsId = 25 }, new { RecipesId = 3, IngredientsId = 7 }, new { RecipesId = 3, IngredientsId = 26 }, new { RecipesId = 3, IngredientsId = 27 },
                                    new { RecipesId = 3, IngredientsId = 28 }, new { RecipesId = 3, IngredientsId = 29 }, new { RecipesId = 3, IngredientsId = 15 }, new { RecipesId = 3, IngredientsId = 30 },
                                    new { RecipesId = 3, IngredientsId = 31 }, new { RecipesId = 3, IngredientsId = 32 }, new { RecipesId = 4, IngredientsId = 33 }, new { RecipesId = 4, IngredientsId = 27 },
                                    new { RecipesId = 4, IngredientsId = 15 }, new { RecipesId = 4, IngredientsId = 34 }, new { RecipesId = 4, IngredientsId = 35 }, new { RecipesId = 4, IngredientsId = 26 },
                                    new { RecipesId = 4, IngredientsId = 7 }, new { RecipesId = 4, IngredientsId = 6 }, new { RecipesId = 4, IngredientsId = 36 }, new { RecipesId = 4, IngredientsId = 22 },
                                    new { RecipesId = 4, IngredientsId = 3 }, new { RecipesId = 4, IngredientsId = 37 }, new { RecipesId = 4, IngredientsId = 38 }, new { RecipesId = 5, IngredientsId = 39 },
                                    new { RecipesId = 5, IngredientsId = 21 }, new { RecipesId = 5, IngredientsId = 40 }, new { RecipesId = 5, IngredientsId = 30 }, new { RecipesId = 5, IngredientsId = 7 },
                                    new { RecipesId = 5, IngredientsId = 26 }, new { RecipesId = 5, IngredientsId = 3 }, new { RecipesId = 5, IngredientsId = 41 }, new { RecipesId = 5, IngredientsId = 42 },
                                    new { RecipesId = 5, IngredientsId = 6 }, new { RecipesId = 6, IngredientsId = 43 }, new { RecipesId = 6, IngredientsId = 15 }, new { RecipesId = 6, IngredientsId = 44 },
                                    new { RecipesId = 6, IngredientsId = 26 }, new { RecipesId = 6, IngredientsId = 30 }, new { RecipesId = 6, IngredientsId = 45 }, new { RecipesId = 6, IngredientsId = 4 },
                                    new { RecipesId = 6, IngredientsId = 38 }, new { RecipesId = 7, IngredientsId = 46 }, new { RecipesId = 7, IngredientsId = 47 }, new { RecipesId = 7, IngredientsId = 6 },
                                    new { RecipesId = 7, IngredientsId = 48 }, new { RecipesId = 7, IngredientsId = 49 }, new { RecipesId = 7, IngredientsId = 50 }, new { RecipesId = 7, IngredientsId = 51 },
                                    new { RecipesId = 7, IngredientsId = 13 }, new { RecipesId = 7, IngredientsId = 44 }, new { RecipesId = 8, IngredientsId = 52 }, new { RecipesId = 8, IngredientsId = 53 },
                                    new { RecipesId = 8, IngredientsId = 54 }, new { RecipesId = 8, IngredientsId = 13 }, new { RecipesId = 8, IngredientsId = 26 }, new { RecipesId = 8, IngredientsId = 15 },
                                    new { RecipesId = 8, IngredientsId = 7 }, new { RecipesId = 8, IngredientsId = 6 }, new { RecipesId = 8, IngredientsId = 35 }, new { RecipesId = 8, IngredientsId = 28 },
                                    new { RecipesId = 8, IngredientsId = 51 }, new { RecipesId = 8, IngredientsId = 55 }, new { RecipesId = 8, IngredientsId = 56 }, new { RecipesId = 8, IngredientsId = 27 },
                                    new { RecipesId = 8, IngredientsId = 39 }, new { RecipesId = 9, IngredientsId = 57 }, new { RecipesId = 9, IngredientsId = 27 }, new { RecipesId = 9, IngredientsId = 26 },
                                    new { RecipesId = 9, IngredientsId = 30 }, new { RecipesId = 9, IngredientsId = 35 }, new { RecipesId = 9, IngredientsId = 15 }, new { RecipesId = 9, IngredientsId = 44 },
                                    new { RecipesId = 9, IngredientsId = 38 }, new { RecipesId = 9, IngredientsId = 41 });
                    });
        }
    }
}
