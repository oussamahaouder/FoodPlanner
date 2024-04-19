using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;

namespace TaskManagerApp.Infrastructure.Adapters
{
    
    public class FoodAdapter
    {
        public readonly DataBaseContext _dataBaseContext;
        public FoodAdapter(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task AddMeal(Meal meal)
        {
            await _dataBaseContext.Meal.AddAsync(meal);
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task<int?> FindIngredient(string ingredientName)
        {
            Ingredient? ingerdient = await _dataBaseContext.Ingredient.FirstOrDefaultAsync(ingredient => ingredient.Name == ingredientName);
             if (ingerdient != null)
            {
                return ingerdient.Id;
            }
            return null;
        }
        public async Task<int> AddMealIngredients(Ingredient ingredient)
        {
            await _dataBaseContext.Ingredient.AddAsync(ingredient);
            await _dataBaseContext.SaveChangesAsync();
            int ingredientId = ingredient.Id;
            return ingredientId;
        }

        public async Task SaveMealIngredients(MealIngredient mealIngredient )
        {
            await _dataBaseContext.MealIngredient.AddAsync(mealIngredient); 
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task<List<Meal>> FetchAllMeals()
        {
            return await _dataBaseContext.Meal.ToListAsync();

        }

        public async Task<Meal?> GetMealById(int mealId)
        {
            Meal? meal = await _dataBaseContext.Meal.FirstOrDefaultAsync(meal => meal.Id == mealId);
            if(meal != null) { return meal; }
            return null;
        }

        public Task DeleteMealById(Meal meal)
        {
             _dataBaseContext.Meal.Remove(meal);
             _dataBaseContext.SaveChanges(); 
             return Task.CompletedTask;
        }
    }
}
