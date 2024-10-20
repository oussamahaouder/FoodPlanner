using TaskManagerApp.Application.UseCases.Command;
using TaskManagerApp.Models;

namespace TaskManagerApp.Domain.Interfaces
{
    public interface IFoodService
    {
        Task<int> CreateMeal(CreateMealRequest mealDto);
        Task<List<Meal>> GetAllMeals();
        Task<List<Ingredient>> GetIngredientsAsync();
        Task DeleteMeal(int mealId);
    }
}
