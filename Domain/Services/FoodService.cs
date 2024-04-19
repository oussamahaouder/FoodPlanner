using TaskManagerApp.Controllers.Requests;
using TaskManagerApp.Domain.Interfaces;
using TaskManagerApp.Infrastructure.Adapters;
using TaskManagerApp.Models;

namespace TaskManagerApp.Domain.Services
{
    public class FoodService : IFoodService
    {
        public readonly FoodAdapter _foodAdapter;

        public FoodService(FoodAdapter foodAdapter)
        {
            _foodAdapter = foodAdapter;
        }

        public async Task CreateMeal(CreateMealRequest mealDto)
        {
           
            Meal meal = new()
            {
               Name = mealDto.MealName,
               Description = mealDto.MealDescription,
              
            };

            await _foodAdapter.AddMeal(meal);
            var mealId = meal.Id;

            await AddIngredients(mealDto.MealIngredients,mealId);
        }

        public async Task<List<Meal>> GetAllMeals()
        {
            List<Meal> allMealsWithoutIngerdients = await _foodAdapter.FetchAllMeals();

            return allMealsWithoutIngerdients; 
        }
        public async Task DeleteMeal(int mealId)
        {

            Meal? mealToDelete = await _foodAdapter.GetMealById(mealId);
           if ( mealToDelete!= null)
            {
               await _foodAdapter.DeleteMealById(mealToDelete);
            }
           else
            {
                throw new Exception("No element foud for the given id");
            }
        }

        public async Task UpdateMeal(UpdateMealRequest mealRequest)
        {
            await Task.Delay(10) ;
        }

        private async Task AddIngredients(List<Ingredient> ingredients , int mealId)
        {
            foreach (var ingredient in ingredients)
            {
                var ingerdientId = await _foodAdapter.FindIngredient(ingredient.Name);
                if (ingerdientId == null )
                {
                    Ingredient ingredientToCreate = new() { Name = ingredient.Name };
                    ingerdientId = await _foodAdapter.AddMealIngredients(ingredientToCreate);

                }

                MealIngredient mealIngredient = new()
                {
                    MealId = mealId,
                    IngredientId = ingerdientId
                };
                await _foodAdapter.SaveMealIngredients(mealIngredient);
            }
        

        }
    }
}
