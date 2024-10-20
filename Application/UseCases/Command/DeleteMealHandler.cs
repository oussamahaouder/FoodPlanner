using MediatR;
using TaskManagerApp.Domain.Interfaces;

namespace TaskManagerApp.Application.UseCases.Command
{
    public class DeleteMealHandler(IFoodService foodService) : IRequestHandler<DeleteMealRequest, Task>
    {
        private readonly IFoodService _foodService = foodService;
        public async Task<Task> Handle(DeleteMealRequest request, CancellationToken cancellationToken)
        {
            await _foodService.DeleteMeal(request.MealId);
            return Task.CompletedTask;
        }
    }
}
