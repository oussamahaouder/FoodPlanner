using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManagerApp.Controllers.Requests;
using TaskManagerApp.Domain.Interfaces;
using TaskManagerApp.Domain.Services;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        public readonly IFoodService _foodService;
        
        public FoodController(IFoodService foodService)
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

        [HttpPut]
        public async Task<ActionResult> UpdateMeal(UpdateMealRequest mealRequest)
        {
            await _foodService.UpdateMeal(mealRequest);
            return Ok(mealRequest);
        }
    }
}
