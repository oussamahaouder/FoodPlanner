using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskManagerApp.Models;

namespace TaskManagerApp.Application.UseCases.Command
{
    public class CreateMealRequest : IRequest<int>
    {
        [Required]
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<Ingredient>? MealIngredients { get; set; }
    }
}
