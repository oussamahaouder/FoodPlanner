using MediatR;
using TaskManagerApp.Domain.Interfaces;

namespace TaskManagerApp.Application.UseCases.Command
{
    public class CreateMealHandler(IFoodService foodService) : IRequestHandler<CreateMealRequest, int>
    {
        private readonly IFoodService _foodService = foodService;  
        public async Task<int> Handle(CreateMealRequest request, CancellationToken cancellationToken)
        {
            return await _foodService.CreateMeal(request);
        }
    }
}
