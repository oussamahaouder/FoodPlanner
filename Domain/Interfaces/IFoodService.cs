using TaskManagerApp.Controllers.Requests;
using TaskManagerApp.Models;

namespace TaskManagerApp.Domain.Interfaces
{
    public interface IFoodService
    {
        public Task CreateMeal(CreateMealRequest mealDto);
        public Task<List<Meal>> GetAllMeals();
        public Task DeleteMeal(int mealId);
        public Task UpdateMeal(UpdateMealRequest mealRequest);
    }
}
