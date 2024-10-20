using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Application.UseCases.Command;
using TaskManagerApp.Application.UseCases.Queries;
using TaskManagerApp.Controllers.Requests;
using TaskManagerApp.Domain.Services;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController(FoodService foodService , IMediator mediator) : ControllerBase
    {
        public readonly FoodService _foodService = foodService;

        public readonly IMediator _mediator = mediator;


        [HttpPost("meal")]
        public async Task<ActionResult> CreateMeal(CreateMealRequestDto createMealRequest)
        {
            try
            {
                var response = await _mediator.Send(new CreateMealRequest
                {
                    MealName = createMealRequest.MealName,
                    MealDescription = createMealRequest.MealDescription,
                    MealIngredients = createMealRequest.MealIngredients,
                });
                return Ok(response);

            }
            catch (Exception ex)
            {
                throw new Exception("error while treating the request {ex}" ,ex);
            }
        }

        [HttpGet("meals")]
        public async Task<ActionResult<List<Meal>>> GetAllTheMeals()
        {
            try
            {
                var response = await _mediator.Send(new GetAllMealsQuery { });
                return Ok(response);
            }

            catch
            {
                return BadRequest("Error with the request");
            }
        }

        [HttpDelete("Meal")]
        public async Task<ActionResult> DeleteMeal(int mealId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteMealRequest
                {
                    MealId = mealId
                });

                return Ok(response.IsCompleted);
            }
            catch (Exception ex)
            {
                throw new Exception("exeption occured {ex}" , ex);
            }
            
        }

        [HttpGet("Ingredient/{id:int}")]
        public async Task<ActionResult> GetIngredientById(int id)
        {
            var response = await _mediator.Send(new GetIngredientByIdQuery
            {
                Id = id
            });
            if ( response == null)
            {
                return BadRequest("Could not find the ingredient with the id "+ id);
            }
            return Ok(response);
        }
        [HttpGet("ingredients")]
        public async Task<ActionResult> GetAllIngerdients()
        {
           var ingedients = await _mediator.Send(new GetAllIngredientsQuery { });
            return Ok(ingedients);
        }

        [HttpPost("ingredients")]
        public async Task<ActionResult> CreateIngredient(List<Ingredient> ingredients)
        {
            var response = await _mediator.Send(new CreateIngredientRequest { ingredients = ingredients });
            if ( response)
            {
                return Ok(response);
            }
            if (!response)
            {
                return BadRequest("Can't save ingeredients");
            }
            throw new Exception("Error");

        }
        

    }
}
