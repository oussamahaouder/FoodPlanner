using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Infrastructure.Interfaces;
using TaskManagerApp.Models;

namespace TaskManagerApp.Infrastructure.Adapters
{
    
    public class FoodAdapter(DataBaseContext dataBaseContext) : IFoodAdapter
    {
        public readonly DataBaseContext _dataBaseContext = dataBaseContext;

        public async Task<int> AddMeal(Meal meal)
        {
            await _dataBaseContext.Meal.AddAsync(meal);
            await _dataBaseContext.SaveChangesAsync();
            return meal.Id;
        }

        public async Task<int?> FindIngredient(string ingredientName)
        {
            var ingerdient = await _dataBaseContext.Ingredient.FirstOrDefaultAsync(ingredient => ingredient.Name == ingredientName);
             if (ingerdient != null)
            {
                return ingerdient.Id;
            }
            return null;
        }
        public async Task<int> AddIngredients(Ingredient ingredient)
        {
            await _dataBaseContext.Ingredient.AddAsync(ingredient);
            await _dataBaseContext.SaveChangesAsync();
            int ingredientId = ingredient.Id;
            return ingredientId;
        }

        public async Task<int> SaveMealIngredients(MealIngredient mealIngredient )
        {
            await _dataBaseContext.MealIngredients.AddAsync(mealIngredient); 
            await _dataBaseContext.SaveChangesAsync();
            return mealIngredient.MealId;
        }

        public async Task<List<MealIngredient>> GetMealIngredientsByMealId(int mealId)
        {
          var ingredients = await _dataBaseContext.MealIngredients
                .Where(ingr => ingr.MealId == mealId)
                .ToListAsync();
            return ingredients;

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
        public async Task<List<Ingredient>> GetIngredients()
        {
            var ingeredients = await _dataBaseContext.Ingredient.ToListAsync();
            return ingeredients;
        }

        public async Task<bool> AddIngredients(List<Ingredient> ingredients)
        {
            try
            {
                await _dataBaseContext.Ingredient.AddRangeAsync(ingredients);
                await _dataBaseContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
             
        }

        public async Task<string?> GetIngredientById(int ingredientId)
        {
            var ingredient = await _dataBaseContext.Ingredient.FindAsync(ingredientId);
            return ingredient?.Name;
                            
        }
        public Task DeleteMealById(Meal meal)
        {
             _dataBaseContext.Meal.Remove(meal);
            _dataBaseContext.SaveChanges(); 
            return Task.CompletedTask;
        }
    }
}
