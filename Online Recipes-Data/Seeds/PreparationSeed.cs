using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Online_Recipes_Domain.Models;

namespace Online_Recipes_Data.Seeds
{
    public class PreparationSeed : IEntityTypeConfiguration<Preparation>
    {
        public void Configure(EntityTypeBuilder<Preparation> builder)
        {
            builder
               .HasData
               (new Preparation
               {
                   Id = 1,
                   Steps =
                   [
                    "Massage the meat with the pepper paste, add the bay leaf broken into pieces and drizzle with the juice of an orange.",
                    "Cut the other orange into thick slices and then into pieces and mix it with the meat. Let marinate for at least 1 hour.",
                    "Peel the chestnuts and set aside. Also peel the onions and cut them into half moons.",
                    "Place the meat and marinade in a pan, add half the onion and olive oil. Mix well and cook, covered and over low heat, for around 50 minutes or until the meat is tender.",
                    "Brown the remaining onion in a large frying pan with the remaining olive oil. Add the chestnuts and season with salt.",
                    "Cut the courgette into sticks and the mushrooms in half and add them to the chestnuts. Sprinkle with a pinch of pepper, paprika and thyme.",
                    "Cover the pan and let it cook gently for about 30 minutes. If necessary, spray with a little water. Mix with the meat and serve."
                   ]
               },
               new Preparation
               {
                   Id = 2,
                   Steps =
                   [
                    "The day before, soak the grain in water.",
                    "Before preparing, drain the grain and place it in a pan with plenty of water, seasoned with half the salt, along with the veal.",
                    "When the grain starts to cook, add the bacon, chorizo, spare ribs and chicken and let it cook for around 1 hour.",
                    "Remove the meat as soon as it is cooked. Add the peeled and diced potatoes, as well as the sliced ​​carrots and striped cabbage. Add water so that the vegetables are covered.",
                    "After 10 minutes, add the dough, season with the remaining salt and, if necessary, add a little more water.",
                    "Cut the meat into pieces and return to the pan. Let it heat up and, before serving, sprinkle with cumin."
                    ]
               },
               new Preparation
               {
                   Id = 3,
                   Steps =
                   [
                    "Pour the olive oil and finely grated or chopped garlic into a pan. Let it cook for a minute. Add the water and bring to a boil.",
                    "Dissolve the flour in a little cold water and, when the water in the pan is boiling, add the flour and stir very well to make corn porridge.",
                    "At the same time, add the cabbage. Season with salt and mix everything.",
                    "Keep stirring to avoid lumps and let the flour cook over medium heat for about 5 minutes, being careful not to let it stick to the pan.",
                    "When the dough has a solid consistency, turn off the heat, place it on a tray and let it cool. Place in the fridge to solidify, at least 3 hours.",
                    "When the dough is cooked, heat the oil, cut the dough into sticks and fry until golden brown.",
                    "Using a sharp knife, sharpen the ends of the bay leaves to create skewers.",
                    "Thread the pieces of meat onto the skewers.",
                    "Season the meat with salt and grill, turning it regularly. When cooked to taste, serve with fried corn sticks."
                    ]
               },
               new Preparation
               {
                   Id = 4,
                   Steps =
                   [
                    "In a pan, place the fish and cover with about a liter and a half of water. Add the salt and bring to the boil. Let it boil for 10 minutes and remove the fish with a slotted spoon. Add the shrimp shells and heads to the fish cooking broth and bring to a boil.",
                    "Peel and chop the garlic cloves, peel the carrots and cut them into slices.",
                    "In a pan, with the olive oil, sauté the chopped garlic cloves and, when they start to brown, the leek and chopped onion. Let cook until the vegetables are soft. Add the carrot slices, tomato and bay leaf. Cover and cook over low heat until the tomato is soft.",
                    "Grind the shrimp shells and heads with a hand blender and strain the broth using a mesh strainer. Pour the broth over the stew and when it boils, add the pasta. Cover and let cook until al dente.",
                    "Clean the fish of skin and bones and break it into large pieces. Add the fish and coriander to the pasta and serve immediately."
                    ]
               },
               new Preparation
               {
                   Id = 5,
                   Steps =
                   [
                    "Peel the potatoes and cut them into very thin sticks to obtain straw potatoes. Soak them in water for about half an hour to remove excess gum.",
                    "Meanwhile, remove the skin and bones from the cod and shred it with your hands.",
                    "Drain the potatoes and dry them well with a towel or kitchen paper. Fry them in the previously heated oil.",
                    "Meanwhile, heat the oil in a frying pan and sauté the sliced ​​onion, peeled and cut into half moons, the garlic, peeled and chopped, and the bay leaf.",
                    "When the onion and garlic start to soften, add the shredded cod and cover the pan.",
                    "Cook over low heat until the cod turns white.",
                    "Remove the bay leaf from the mixture and add the fries.",
                    "Add the eggs, previously beaten, stir them gently, allowing them to coat all the ingredients. Don't let the eggs cook and dry out too much.",
                    "Before serving, sprinkle with chopped parsley and decorate with olives."
                    ]
               },
               new Preparation
               {
                   Id = 6,
                   Steps =
                   [
                    "Season the fillets with half the salt, pepper and chopped garlic.",
                    "Heat half the olive oil in a non-stick frying pan and when it is hot, add the fillets and cook for 2 minutes on each side. Remove and reserve.",
                    "Add the remaining olive oil, add the fennel and the juice and zest of an orange. Scrape the bottom with a wooden spoon.",
                    "Add the segments of the other orange, the remaining salt and pepper.",
                    "Return the fillets to the pan and cook for another 3 minutes."
                    ]
               },
               new Preparation
               {
                   Id = 7,
                   Steps =
                   [
                    "Cut a pear with the skin into thin slices. Heat two tablespoons of butter in a frying pan and sauté the pear slices until golden or slightly caramelized. Reserve.",
                    "Cut the remaining pears into small cubes, also with the skin on. Reserve.",
                    "In a high frying pan, heat two tablespoons of butter, add the chopped onion and cook for 2 minutes. Add the rice and mix. Add the glass of wine and let it absorb.",
                    "Then, add ladlefuls of broth (vegetable broth diluted in 1.5L of water), let it absorb completely until adding more broth again and stir constantly. Do this process for around 15 minutes.",
                    "After 15 minutes, add the pear cubes and continue to stir.",
                    "When the rice is cooked, add half of the Azeitão cheese paste, the remaining butter and mix.",
                    "Distribute between four plates and place the remaining cheese paste and sautéed pear slices on top.",
                    "Finish with thyme and pepper."
                    ]
               },
                new Preparation
                {
                    Id = 8,
                    Steps =
                   [
                    "Preheat the oven to 180ºC. Clean the mushrooms with kitchen paper, remove the stems and, using a spoon, carefully excavate part of the pulp, without tearing the caps. Reserve the feet and pulp.",
                    "Place the mushroom caps on a baking tray lined with baking paper and place ⅔ of the pumpkin in slices about 5 mm thick next to them.",
                    "Remove the fibrous base of the asparagus, cut off the spiked ends and add them to the tray. Reserve the rest.",
                    "Sprinkle with the thyme, half the minced garlic and ½ teaspoon of salt. Drizzle with a tablespoon of olive oil and place the tray in the oven for around 10 to 15 minutes.",
                    "For the filling, heat 1 ½ tablespoons of olive oil in a wide frying pan, add the onion and the remaining chopped garlic and let it brown. Add the mushroom stems and pulp and the finely chopped sun-dried tomato. Add the remaining asparagus cut into slices and the remaining diced pumpkin.",
                    "Season with ½ teaspoon of salt and sauté over medium to high heat, stirring frequently for about 5 minutes.",
                    "Add the crumbled cornbread crumbs and cook for another 2 to 3 minutes.",
                    "When cooked, remove the mushroom caps from the oven and divide the filling between them, distributing the cheese and almonds on top. Place back in the oven for another 10 to 15 minutes.",
                    "Meanwhile, heat the remaining oil in a pan, add the rice and fry for about 1 minute, stirring frequently.",
                    "Pour in boiling water, season with the remaining salt and cook covered for 15 minutes. When serving, sprinkle with chopped parsley."
                    ]
                },
                new Preparation
                {
                    Id = 9,
                    Steps =
                   [
                    "Tear the bread into pieces into a bowl, cover them with hot water and let the bread absorb.",
                    "Crush the garlic cloves, with the skin, and brown them in the hot olive oil. Remove the skin from the garlic, add the tomato, cleaned of seeds and chopped into small cubes, and cook over low heat for about 5 minutes.",
                    "Squeeze the bread, if necessary to remove excess water, and add it to the tomato. Keep stirring constantly, over the heat, until the bread is at the desired consistency.",
                    "Mix the coriander into the mixture and place the bread in two bowls. Make some wells in the middle, add the egg yolks and mix quickly. Serve immediately."
                    ]
                });
        }
    }
}
