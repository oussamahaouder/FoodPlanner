using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;

namespace TaskManagerApp.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }

        public DbSet<MealIngredient> MealIngredient{ get; set; }
    }
}
