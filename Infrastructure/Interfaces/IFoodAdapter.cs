using TaskManagerApp.Models;

namespace TaskManagerApp.Infrastructure.Interfaces
{
    public interface IFoodAdapter
    {
        public Task AddMeal(Meal meal);
        public Task<int?> FindIngredient(string ingredientName);
        public Task<int> AddMealIngredients(Ingredient ingredient);
        public Task SaveMealIngredients(MealIngredient mealIngredient);
        public Task<List<Meal>> FetchAllMeals();
        public Task<Meal?> GetMealById(int mealId);
        public Task DeleteMealById(Meal meal);
    }
}
