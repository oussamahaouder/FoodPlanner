using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp.Models
{
    public class MealIngredient
    {
        [Key]
        public int Id { get; set; } // Assuming this is the primary key of the MealIngredient table

        [ForeignKey("Meal")]
        public int MealId { get; set; }

        [ForeignKey("Ingredient")]
        public int? IngredientId { get; set; }

        // Navigation properties
        public virtual Meal Meal { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
