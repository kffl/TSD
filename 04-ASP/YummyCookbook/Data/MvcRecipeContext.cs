using Microsoft.EntityFrameworkCore;
using YummyCookbook.Models;

namespace YummyCookbook.Data
{
    public class MvcRecipeContext : DbContext
    {
        public MvcRecipeContext (DbContextOptions<MvcRecipeContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipe { get; set; }
    }
}