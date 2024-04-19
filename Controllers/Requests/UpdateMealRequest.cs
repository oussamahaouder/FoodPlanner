using System.ComponentModel.DataAnnotations;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers.Requests
{
    public class UpdateMealRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? MealName { get; set; }
        public string? MealDescription { get; set; }
        public List<Ingredient>? MealIngredients { get; set; }
    }
}
