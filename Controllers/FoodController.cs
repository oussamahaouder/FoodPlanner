using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManagerApp.Controllers.Requests;
using TaskManagerApp.Domain.Services;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        public readonly FoodService _foodService;
        
        public FoodController(FoodService foodService)
        {   
                _foodService = foodService;
        }


        [HttpPost("CreateMeal")]
        public async Task<ActionResult> CreateMeal(CreateMealRequest createMealRequest)
        {
           await _foodService.CreateMeal(createMealRequest);

            return Ok();
        }
        [HttpGet("GetAllMeals")]
        public async Task<ActionResult<List<Meal>>> GetAllTheMeals()
        {
            return await _foodService.GetAllMeals();
        }
        [HttpDelete("Meal")]
        public async Task<ActionResult> DeleteMeal(int mealId)
        {
            await _foodService.DeleteMeal(mealId);
           return Ok();
            
        }
    }
}
