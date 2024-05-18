using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Online_Recipes_Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient_Quantity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Measure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient_Quantity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preparation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Steps = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Star = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    CookingTime = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient_QuantityRecipeIngredient",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    Ingredient_QuantitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient_QuantityRecipeIngredient", x => new { x.IngredientsId, x.Ingredient_QuantitiesId });
                    table.ForeignKey(
                        name: "FK_Ingredient_QuantityRecipeIngredient_Ingredient_Quantity_Ingredient_QuantitiesId",
                        column: x => x.Ingredient_QuantitiesId,
                        principalTable: "Ingredient_Quantity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredient_QuantityRecipeIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRecipe",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRecipe", x => new { x.RecipesId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentRecipe",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRecipe", x => new { x.CommentsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_CommentRecipe_Comment_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient_QuantityRecipe",
                columns: table => new
                {
                    Ingredient_QuantitiesId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient_QuantityRecipe", x => new { x.Ingredient_QuantitiesId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_Ingredient_QuantityRecipe_Ingredient_Quantity_Ingredient_QuantitiesId",
                        column: x => x.Ingredient_QuantitiesId,
                        principalTable: "Ingredient_Quantity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredient_QuantityRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientRecipe",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientRecipe", x => new { x.RecipesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreparationRecipe",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    PreparationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreparationRecipe", x => new { x.RecipesId, x.PreparationsId });
                    table.ForeignKey(
                        name: "FK_PreparationRecipe_Preparation_PreparationsId",
                        column: x => x.PreparationsId,
                        principalTable: "Preparation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreparationRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingRecipe",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    RatingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingRecipe", x => new { x.RecipesId, x.RatingsId });
                    table.ForeignKey(
                        name: "FK_RatingRecipe_Rating_RatingsId",
                        column: x => x.RatingsId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RatingRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeUser",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUser", x => new { x.RecipesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RecipeUser_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Meat" },
                    { 2, "Fish" },
                    { 3, "Vegetarian" }
                });

            migrationBuilder.InsertData(
                table: "Ingredient_Quantity",
                columns: new[] { "Id", "Measure", "Quantity" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 3, 1 },
                    { 3, 0, 1 },
                    { 4, 4, 2 },
                    { 5, 3, 2 },
                    { 6, 3, 4 },
                    { 7, 2, 100 },
                    { 8, 1, 100 },
                    { 9, 2, 150 },
                    { 10, 1, 150 },
                    { 11, 2, 200 },
                    { 12, 1, 200 },
                    { 13, 2, 250 },
                    { 14, 1, 250 },
                    { 15, 2, 300 },
                    { 16, 1, 300 },
                    { 17, 1, 400 },
                    { 18, 1, 500 },
                    { 19, 1, 600 },
                    { 20, 1, 800 },
                    { 21, 1, 700 },
                    { 22, 4, 6 },
                    { 23, 3, 12 },
                    { 24, 1, 40 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Product" },
                values: new object[,]
                {
                    { 1, "Pork" },
                    { 2, "Pepper paste" },
                    { 3, "Blonde" },
                    { 4, "Orange" },
                    { 5, "Brunette" },
                    { 6, "onion" },
                    { 7, "Olive oil" },
                    { 8, "Shall" },
                    { 9, "Curget" },
                    { 10, "Mushroom" },
                    { 11, "back pepper" },
                    { 12, "Sweet chili" },
                    { 13, "Dried thyme" },
                    { 14, "chickpea" },
                    { 15, "salt" },
                    { 16, "veal" },
                    { 17, "bacon" },
                    { 18, "meat sausage" },
                    { 19, "spare ribs" },
                    { 20, "chicken" },
                    { 21, "potato" },
                    { 22, "carrot" },
                    { 23, "savoy cabbage" },
                    { 24, "scratched pasta" },
                    { 25, "cumin" },
                    { 26, "garlic" },
                    { 27, "water" },
                    { 28, "yellow corn flour" },
                    { 29, "green soup" },
                    { 30, "oil" },
                    { 31, "green laurel sticks" },
                    { 32, "fillet meat in cubes" },
                    { 33, "ling" },
                    { 34, "shrimp" },
                    { 35, "tomato" },
                    { 36, "leek" },
                    { 37, "noodle dough" },
                    { 38, "coriander" },
                    { 39, "parsley" },
                    { 40, "cod fish" },
                    { 41, "eggs" },
                    { 42, "black olive" },
                    { 43, "sea bream" },
                    { 44, "pepper" },
                    { 45, "fennel" },
                    { 46, "pear" },
                    { 47, "butter" },
                    { 48, "white wine" },
                    { 49, "risotto rice" },
                    { 50, "broth" },
                    { 51, "cheese" },
                    { 52, "portobello mushroom" },
                    { 53, "pumpkin" },
                    { 54, "asparagus" },
                    { 55, "almond" },
                    { 56, "rice" },
                    { 57, "bread" }
                });

            migrationBuilder.InsertData(
                table: "Preparation",
                columns: new[] { "Id", "Steps" },
                values: new object[,]
                {
                    { 1, "Massage the meat with the pepper paste, add the bay leaf broken into pieces and drizzle with the juice of an orange." },
                    { 2, "Cut the other orange into thick slices and then into pieces and mix it with the meat. Let marinate for at least 1 hour." },
                    { 3, "Peel the chestnuts and set aside. Also peel the onions and cut them into half moons." },
                    { 4, "Place the meat and marinade in a pan, add half the onion and olive oil. Mix well and cook, covered and over low heat, for around 50 minutes or until the meat is tender." },
                    { 5, "Brown the remaining onion in a large frying pan with the remaining olive oil. Add the chestnuts and season with salt." },
                    { 6, "Cut the courgette into sticks and the mushrooms in half and add them to the chestnuts. Sprinkle with a pinch of pepper, paprika and thyme." },
                    { 7, "Cover the pan and let it cook gently for about 30 minutes. If necessary, spray with a little water. Mix with the meat and serve." },
                    { 8, "The day before, soak the grain in water." },
                    { 9, "Before preparing, drain the grain and place it in a pan with plenty of water, seasoned with half the salt, along with the veal." },
                    { 10, "When the grain starts to cook, add the bacon, chorizo, spare ribs and chicken and let it cook for around 1 hour." },
                    { 11, "Remove the meat as soon as it is cooked. Add the peeled and diced potatoes, as well as the sliced ​​carrots and striped cabbage. Add water so that the vegetables are covered." },
                    { 12, "After 10 minutes, add the dough, season with the remaining salt and, if necessary, add a little more water." },
                    { 13, "Cut the meat into pieces and return to the pan. Let it heat up and, before serving, sprinkle with cumin." },
                    { 14, "Pour the olive oil and finely grated or chopped garlic into a pan. Let it cook for a minute. Add the water and bring to a boil." },
                    { 15, "Dissolve the flour in a little cold water and, when the water in the pan is boiling, add the flour and stir very well to make corn porridge." },
                    { 16, "At the same time, add the cabbage. Season with salt and mix everything." },
                    { 17, "Keep stirring to avoid lumps and let the flour cook over medium heat for about 5 minutes, being careful not to let it stick to the pan." },
                    { 18, "When the dough has a solid consistency, turn off the heat, place it on a tray and let it cool. Place in the fridge to solidify, at least 3 hours." },
                    { 19, "When the dough is cooked, heat the oil, cut the dough into sticks and fry until golden brown." },
                    { 20, "Using a sharp knife, sharpen the ends of the bay leaves to create skewers." },
                    { 21, "Thread the pieces of meat onto the skewers." },
                    { 22, "Season the meat with salt and grill, turning it regularly. When cooked to taste, serve with fried corn sticks." },
                    { 23, "In a pan, place the fish and cover with about a liter and a half of water. Add the salt and bring to the boil. Let it boil for 10 minutes and remove the fish with a slotted spoon. Add the shrimp shells and heads to the fish cooking broth and bring to a boil." },
                    { 24, "Peel and chop the garlic cloves, peel the carrots and cut them into slices." },
                    { 25, "In a pan, with the olive oil, sauté the chopped garlic cloves and, when they start to brown, the leek and chopped onion. Let cook until the vegetables are soft. Add the carrot slices, tomato and bay leaf. Cover and cook over low heat until the tomato is soft." },
                    { 26, "Grind the shrimp shells and heads with a hand blender and strain the broth using a mesh strainer. Pour the broth over the stew and when it boils, add the pasta. Cover and let cook until al dente." },
                    { 27, "Clean the fish of skin and bones and break it into large pieces. Add the fish and coriander to the pasta and serve immediately." },
                    { 28, "Peel the potatoes and cut them into very thin sticks to obtain straw potatoes. Soak them in water for about half an hour to remove excess gum." },
                    { 29, "Meanwhile, remove the skin and bones from the cod and shred it with your hands." },
                    { 30, "Drain the potatoes and dry them well with a towel or kitchen paper. Fry them in the previously heated oil." },
                    { 31, "Meanwhile, heat the oil in a frying pan and sauté the sliced ​​onion, peeled and cut into half moons, the garlic, peeled and chopped, and the bay leaf." },
                    { 32, "When the onion and garlic start to soften, add the shredded cod and cover the pan." },
                    { 33, "Cook over low heat until the cod turns white." },
                    { 34, "Remove the bay leaf from the mixture and add the fries." },
                    { 35, "Add the eggs, previously beaten, stir them gently, allowing them to coat all the ingredients. Don't let the eggs cook and dry out too much." },
                    { 36, "Before serving, sprinkle with chopped parsley and decorate with olives." },
                    { 37, "Season the fillets with half the salt, pepper and chopped garlic." },
                    { 38, "Heat half the olive oil in a non-stick frying pan and when it is hot, add the fillets and cook for 2 minutes on each side. Remove and reserve." },
                    { 39, "Add the remaining olive oil, add the fennel and the juice and zest of an orange. Scrape the bottom with a wooden spoon." },
                    { 40, "Add the segments of the other orange, the remaining salt and pepper." },
                    { 41, "Return the fillets to the pan and cook for another 3 minutes." },
                    { 42, "Cut a pear with the skin into thin slices. Heat two tablespoons of butter in a frying pan and sauté the pear slices until golden or slightly caramelized. Reserve." },
                    { 43, "Cut the remaining pears into small cubes, also with the skin on. Reserve." },
                    { 44, "In a high frying pan, heat two tablespoons of butter, add the chopped onion and cook for 2 minutes. Add the rice and mix. Add the glass of wine and let it absorb." },
                    { 45, "Then, add ladlefuls of broth (vegetable broth diluted in 1.5L of water), let it absorb completely until adding more broth again and stir constantly. Do this process for around 15 minutes." },
                    { 46, "After 15 minutes, add the pear cubes and continue to stir." },
                    { 47, "When the rice is cooked, add half of the Azeitão cheese paste, the remaining butter and mix." },
                    { 48, "Distribute between four plates and place the remaining cheese paste and sautéed pear slices on top." },
                    { 49, "Finish with thyme and pepper." },
                    { 50, "Preheat the oven to 180ºC. Clean the mushrooms with kitchen paper, remove the stems and, using a spoon, carefully excavate part of the pulp, without tearing the caps. Reserve the feet and pulp." },
                    { 51, "Place the mushroom caps on a baking tray lined with baking paper and place ⅔ of the pumpkin in slices about 5 mm thick next to them." },
                    { 52, "Remove the fibrous base of the asparagus, cut off the spiked ends and add them to the tray. Reserve the rest." },
                    { 53, "Sprinkle with the thyme, half the minced garlic and ½ teaspoon of salt. Drizzle with a tablespoon of olive oil and place the tray in the oven for around 10 to 15 minutes." },
                    { 54, "For the filling, heat 1 ½ tablespoons of olive oil in a wide frying pan, add the onion and the remaining chopped garlic and let it brown. Add the mushroom stems and pulp and the finely chopped sun-dried tomato. Add the remaining asparagus cut into slices and the remaining diced pumpkin." },
                    { 55, "Season with ½ teaspoon of salt and sauté over medium to high heat, stirring frequently for about 5 minutes." },
                    { 56, "Add the crumbled cornbread crumbs and cook for another 2 to 3 minutes." },
                    { 57, "When cooked, remove the mushroom caps from the oven and divide the filling between them, distributing the cheese and almonds on top. Place back in the oven for another 10 to 15 minutes." },
                    { 58, "Meanwhile, heat the remaining oil in a pan, add the rice and fry for about 1 minute, stirring frequently." },
                    { 59, "Pour in boiling water, season with the remaining salt and cook covered for 15 minutes. When serving, sprinkle with chopped parsley." },
                    { 60, "Tear the bread into pieces into a bowl, cover them with hot water and let the bread absorb." },
                    { 61, "Crush the garlic cloves, with the skin, and brown them in the hot olive oil. Remove the skin from the garlic, add the tomato, cleaned of seeds and chopped into small cubes, and cook over low heat for about 5 minutes." },
                    { 62, "Squeeze the bread, if necessary to remove excess water, and add it to the tomato. Keep stirring constantly, over the heat, until the bread is at the desired consistency." },
                    { 63, "Mix the coriander into the mixture and place the bread in two bowls. Make some wells in the middle, add the egg yolks and mix quickly. Serve immediately." }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Star" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 3 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookingTime", "CreateDate", "Description", "Difficulty", "IsApproved", "ModifiedDate", "Name", "Photo" },
                values: new object[,]
                {
                    { 1, 90, new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5668), "Discover the authenticity of our pork Rojões with chestnuts. Enjoy irresistible flavors and gastronomic tradition, inspired by the richness of the Portuguese Mediterranean Diet!", 0, "true", new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5717), "Pork rojões with chestnutts", "/assets/Pork rojões with chestnuts.jpg" },
                    { 2, 30, new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5723), "In Viseu, to moralize the troops who were going through difficult times, instructions were given to reinforce their diet. From the barracks to the table, Viseu-style ranch was born, a dish that combines chickpeas, potatoes, vegetables, thick pasta and pork, veal and chicken.", 1, "true", new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5724), "Viseu`s Ranch", "/assets/Viseu Ranch.jpg" },
                    { 3, 60, new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5727), "Probably the best-known Madeiran dish outside the archipelago. Kebabs are usually accompanied with fried corn, a snack made with cooked corn flour, then cut into cubes and fried, which is almost as good as the kebab itself.", 1, "true", new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5728), "Madeiran kebabs with fried corn", "/assets/Madeiran kebabs with fried corn.jpg" },
                    { 4, 60, new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5730), "Fish pasta is a main course meal, but can be served as a starter for a lighter second course.", 0, "true", new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5731), "Fish pasta", "/assets/Fish pasta.jpg" },
                    { 5, 45, new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5733), "With cod, eggs and potatoes, this is one of the most popular recipes among the Portuguese. Easy and quick to make, you can easily adapt the method and try it with fish, shredded chicken or even leek.", 1, "true", new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5734), "Cod fish à Brás", "/assets/Cod fish à Brás.jpg" },
                    { 6, 20, new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5736), "Fruits such as orange, lemon or tangerine are popular in countless recipes. Prepare these sea bream fillets with orange sauce and make the most of the color and sweet flavor in a quick and healthy meal.", 1, "true", new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5738), "Sea bream fillets with orange sauce", "/assets/Sea bream fillets with orange sauce.jpg" },
                    { 7, 30, new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5740), "This risotto combines the traditional flavor of Azeitão cheese and the sweetness of pear, representing the gastronomic authenticity of Portugal, with Italian influences.", 0, "true", new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5741), "Azeitão Cheese and pear risotto", "/assets/Azeitão Cheese and pear risotto.jpg" },
                    { 8, 60, new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5743), "Try stuffed Portobello mushrooms for a balanced meal. Rich in nutrients and vegetable protein, they are ideal for vegetarian diets.", 2, "true", new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5744), "Stuffed Portobello Mushrooms", "/assets/Stuffed Portobello Mushrooms.jpg" },
                    { 9, 25, new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5746), "Use leftover carcasses (papos-secos) or mixed bread and prepare a delicious bread soup with coriander and egg. A typical Portuguese dish, vegetarian and without food waste.", 0, "true", new DateTime(2024, 5, 18, 19, 46, 6, 615, DateTimeKind.Local).AddTicks(5747), "Açorda with coriander and egg", "/assets/Açorda with coriander and egg.jpg" }
                });

            migrationBuilder.InsertData(
                table: "CategoryRecipe",
                columns: new[] { "CategoriesId", "RecipesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 }
                });

            migrationBuilder.InsertData(
                table: "IngredientRecipe",
                columns: new[] { "IngredientsId", "RecipesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 2 },
                    { 15, 2 },
                    { 16, 2 },
                    { 17, 2 },
                    { 18, 2 },
                    { 19, 2 },
                    { 20, 2 },
                    { 21, 2 },
                    { 22, 2 },
                    { 23, 2 },
                    { 24, 2 },
                    { 25, 2 },
                    { 7, 3 },
                    { 15, 3 },
                    { 26, 3 },
                    { 27, 3 },
                    { 28, 3 },
                    { 29, 3 },
                    { 30, 3 },
                    { 31, 3 },
                    { 32, 3 },
                    { 3, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 15, 4 },
                    { 22, 4 },
                    { 26, 4 },
                    { 27, 4 },
                    { 33, 4 },
                    { 34, 4 },
                    { 35, 4 },
                    { 36, 4 },
                    { 37, 4 },
                    { 38, 4 },
                    { 3, 5 },
                    { 6, 5 },
                    { 7, 5 },
                    { 21, 5 },
                    { 26, 5 },
                    { 30, 5 },
                    { 39, 5 },
                    { 40, 5 },
                    { 41, 5 },
                    { 42, 5 },
                    { 4, 6 },
                    { 15, 6 },
                    { 26, 6 },
                    { 30, 6 },
                    { 38, 6 },
                    { 43, 6 },
                    { 44, 6 },
                    { 45, 6 },
                    { 6, 7 },
                    { 13, 7 },
                    { 44, 7 },
                    { 46, 7 },
                    { 47, 7 },
                    { 48, 7 },
                    { 49, 7 },
                    { 50, 7 },
                    { 51, 7 },
                    { 6, 8 },
                    { 7, 8 },
                    { 13, 8 },
                    { 15, 8 },
                    { 26, 8 },
                    { 27, 8 },
                    { 28, 8 },
                    { 35, 8 },
                    { 39, 8 },
                    { 51, 8 },
                    { 52, 8 },
                    { 53, 8 },
                    { 54, 8 },
                    { 55, 8 },
                    { 56, 8 },
                    { 15, 9 },
                    { 26, 9 },
                    { 27, 9 },
                    { 30, 9 },
                    { 35, 9 },
                    { 38, 9 },
                    { 41, 9 },
                    { 44, 9 },
                    { 57, 9 }
                });

            migrationBuilder.InsertData(
                table: "Ingredient_QuantityRecipeIngredient",
                columns: new[] { "Ingredient_QuantitiesId", "IngredientsId" },
                values: new object[,]
                {
                    { 19, 1 },
                    { 5, 2 },
                    { 1, 3 },
                    { 5, 4 },
                    { 20, 5 },
                    { 5, 6 },
                    { 7, 7 },
                    { 1, 8 },
                    { 16, 9 },
                    { 16, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 18, 14 },
                    { 1, 15 },
                    { 18, 16 },
                    { 12, 17 },
                    { 12, 18 },
                    { 18, 19 },
                    { 17, 20 },
                    { 18, 21 },
                    { 14, 22 },
                    { 3, 23 },
                    { 18, 24 },
                    { 1, 25 },
                    { 6, 26 },
                    { 13, 27 },
                    { 12, 28 },
                    { 10, 29 },
                    { 15, 30 },
                    { 6, 31 },
                    { 3, 32 },
                    { 21, 33 },
                    { 18, 34 },
                    { 12, 35 },
                    { 8, 36 },
                    { 14, 37 },
                    { 1, 38 },
                    { 1, 39 },
                    { 5, 40 },
                    { 22, 41 },
                    { 23, 42 },
                    { 18, 43 },
                    { 1, 44 },
                    { 8, 45 },
                    { 16, 46 },
                    { 14, 47 },
                    { 7, 48 },
                    { 16, 49 },
                    { 3, 50 },
                    { 14, 51 },
                    { 21, 52 },
                    { 19, 53 },
                    { 12, 54 },
                    { 24, 55 },
                    { 14, 56 },
                    { 12, 57 }
                });

            migrationBuilder.InsertData(
                table: "PreparationRecipe",
                columns: new[] { "PreparationsId", "RecipesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 2 },
                    { 13, 2 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 3 },
                    { 17, 3 },
                    { 18, 3 },
                    { 19, 3 },
                    { 20, 3 },
                    { 21, 3 },
                    { 22, 3 },
                    { 23, 4 },
                    { 24, 4 },
                    { 25, 4 },
                    { 26, 4 },
                    { 27, 4 },
                    { 28, 5 },
                    { 29, 5 },
                    { 30, 5 },
                    { 31, 5 },
                    { 32, 5 },
                    { 33, 5 },
                    { 34, 5 },
                    { 35, 5 },
                    { 36, 5 },
                    { 37, 6 },
                    { 38, 6 },
                    { 39, 6 },
                    { 40, 6 },
                    { 41, 6 },
                    { 42, 7 },
                    { 43, 7 },
                    { 44, 7 },
                    { 45, 7 },
                    { 46, 7 },
                    { 47, 7 },
                    { 48, 7 },
                    { 49, 7 },
                    { 50, 8 },
                    { 51, 8 },
                    { 52, 8 },
                    { 53, 8 },
                    { 54, 8 },
                    { 55, 8 },
                    { 56, 8 },
                    { 57, 8 },
                    { 58, 8 },
                    { 59, 8 },
                    { 60, 9 },
                    { 61, 9 },
                    { 62, 9 },
                    { 63, 9 }
                });

            migrationBuilder.InsertData(
                table: "RatingRecipe",
                columns: new[] { "RatingsId", "RecipesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 3, 6 },
                    { 1, 7 },
                    { 2, 8 },
                    { 3, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecipe_CategoriesId",
                table: "CategoryRecipe",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRecipe_RecipesId",
                table: "CommentRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_QuantityRecipe_RecipesId",
                table: "Ingredient_QuantityRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_QuantityRecipeIngredient_Ingredient_QuantitiesId",
                table: "Ingredient_QuantityRecipeIngredient",
                column: "Ingredient_QuantitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientRecipe_IngredientsId",
                table: "IngredientRecipe",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Product",
                table: "Ingredients",
                column: "Product",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreparationRecipe_PreparationsId",
                table: "PreparationRecipe",
                column: "PreparationsId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingRecipe_RatingsId",
                table: "RatingRecipe",
                column: "RatingsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUser_UsersId",
                table: "RecipeUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRecipe");

            migrationBuilder.DropTable(
                name: "CommentRecipe");

            migrationBuilder.DropTable(
                name: "Ingredient_QuantityRecipe");

            migrationBuilder.DropTable(
                name: "Ingredient_QuantityRecipeIngredient");

            migrationBuilder.DropTable(
                name: "IngredientRecipe");

            migrationBuilder.DropTable(
                name: "PreparationRecipe");

            migrationBuilder.DropTable(
                name: "RatingRecipe");

            migrationBuilder.DropTable(
                name: "RecipeUser");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Ingredient_Quantity");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Preparation");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
