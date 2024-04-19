using System.ComponentModel.DataAnnotations;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers.Requests
{
    public class CreateMealRequest 
    {
       
        [Required]      
        public required string MealName { get; set;}  
        public string? MealDescription { get; set;}
        public List<Ingredient>? MealIngredients { get; set; }
    }
}
