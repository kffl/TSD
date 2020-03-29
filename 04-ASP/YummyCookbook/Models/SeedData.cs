using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YummyCookbook.Data;
using System;
using System.Linq;

namespace YummyCookbook.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcRecipeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcRecipeContext>>()))
            {
                // Look for any movies.
                if (context.Recipe.Any())
                {
                    return;   // DB has been seeded
                }

                context.Recipe.AddRange(
                    new Recipe
                    {
                        Name = "A recipe",
                        Time = 90,
                        Difficulty = "Easy",
                        NoLikes = 1337,
                        Ingredients = "123 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sapien velit, aliquet eget commodo nec, auctor a sapien. Nam eu neque vulputate diam rhoncus faucibus.",
                        Process = "123 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sapien velit, aliquet eget commodo nec, auctor a sapien. Nam eu neque vulputate diam rhoncus faucibus. Curabitur quis varius libero. Lorem.",
                        TipsAndTricks = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sapien velit, aliquet eget commodo nec, auctor a sapien. Nam eu neque vulputate diam rhoncus faucibus. Curabitur quis varius libero. Lorem."
                    },

                    new Recipe
                    {
                        Name = "Another recipe",
                        Time = 45,
                        Difficulty = "Easy",
                        NoLikes = 1234,
                        Ingredients = "ASDF Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sapien velit, aliquet eget commodo nec, auctor a sapien. Nam eu neque vulputate diam rhoncus faucibus.",
                        Process = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sapien velit, aliquet eget commodo nec, auctor a sapien. Nam eu neque vulputate diam rhoncus faucibus. Curabitur quis varius libero. Lorem.",
                        TipsAndTricks = "LLL Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sapien velit, aliquet eget commodo nec, auctor a sapien. Nam eu neque vulputate diam rhoncus faucibus. Curabitur quis varius libero. Lorem."
                    },

                    new Recipe
                    {
                        Name = "Yet another recipe",
                        Time = 30,
                        Difficulty = "Hard",
                        NoLikes = 999,
                        Ingredients = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sapien velit, aliquet eget commodo nec, auctor a sapien. Nam eu neque vulputate diam rhoncus faucibus.",
                        Process = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sapien velit, aliquet eget commodo nec, auctor a sapien. Nam eu neque vulputate diam rhoncus faucibus. Curabitur quis varius libero. Lorem.",
                        TipsAndTricks = "QWERTY Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sapien velit, aliquet eget commodo nec, auctor a sapien. Nam eu neque vulputate diam rhoncus faucibus. Curabitur quis varius libero. Lorem."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}