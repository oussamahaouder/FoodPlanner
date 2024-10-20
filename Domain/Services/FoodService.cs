
using TaskManagerApp.Application.UseCases.Command;
using TaskManagerApp.Domain.Interfaces;
using TaskManagerApp.Infrastructure;
using TaskManagerApp.Infrastructure.Adapters;
using TaskManagerApp.Infrastructure.Interfaces;
using TaskManagerApp.Models;

namespace TaskManagerApp.Domain.Services
{
    public class FoodService(FoodAdapter foodAdapter) : IFoodService
    {
        public readonly IFoodAdapter _foodAdapter = foodAdapter;

        public async Task<int> CreateMeal(CreateMealRequest mealDto)
        {
           
            Meal meal = new()
            {
               Name = mealDto.MealName,
               Description = mealDto.MealDescription,
              
            };

            await _foodAdapter.AddMeal(meal);
            var mealId = meal.Id;

            await AddIngredients(mealDto.MealIngredients,mealId);
            return mealId;
            
        }

        public async Task<List<Meal>> GetAllMeals()
        {
            var allMealsWithoutIngerdients = await _foodAdapter.FetchAllMeals();
            foreach (var meal in  allMealsWithoutIngerdients)
            {

                // Assign only the IngredientIds to a separate list
                meal.IngredientIds = (await _foodAdapter.GetMealIngredientsByMealId(meal.Id))
                                    .Select(ingr => ingr.IngredientId)
                                    .ToList();
            }

            return allMealsWithoutIngerdients;
        }

        public async Task<List<Ingredient>> GetIngredientsAsync()
        {
            var ingeredients = await _foodAdapter.GetIngredients();
            return ingeredients;
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

        private async Task AddIngredients(List<Ingredient> ingredients , int mealId)
        {
            foreach (var ingredient in ingredients)
            {
                var ingerdientId = await _foodAdapter.FindIngredient(ingredient.Name);
                if (ingerdientId == null )
                {
                    Ingredient ingredientToCreate = new() { Name = ingredient.Name };
                    ingerdientId = await _foodAdapter.AddIngredients(ingredientToCreate);

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
