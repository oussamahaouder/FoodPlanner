
using System.Threading.Tasks;
using TaskManagerApp.Models;

namespace TaskManagerApp.Infrastructure.Interfaces
{
    public interface IFoodAdapter
    {
        Task<int> AddMeal(Meal meal);
        Task<int?> FindIngredient(string ingredientName);
        Task<int> AddIngredients(Ingredient ingredient);
        Task<int> SaveMealIngredients(MealIngredient mealIngredient);
        Task<Meal?> GetMealById(int mealId);
        Task<List<Meal>> FetchAllMeals();
        Task<List<Ingredient>> GetIngredients();
        Task DeleteMealById(Meal meal);
        Task<List<MealIngredient>> GetMealIngredientsByMealId(int mealId);
        Task<bool> AddIngredients(List<Ingredient> ingredients);
        Task<string?> GetIngredientById(int ingredientId);
    }
}
