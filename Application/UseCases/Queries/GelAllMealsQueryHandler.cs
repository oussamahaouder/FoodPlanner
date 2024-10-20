using MediatR;
using TaskManagerApp.Domain.Interfaces;
using TaskManagerApp.Models;

namespace TaskManagerApp.Application.UseCases.Queries
{
    public class GelAllMealsQueryHandler(IFoodService foodService) : IRequestHandler<GetAllMealsQuery, List<Meal>>
    {
        private readonly IFoodService _foodService = foodService;

        public Task<List<Meal>> Handle(GetAllMealsQuery request, CancellationToken cancellationToken)
        {
            return _foodService.GetAllMeals();
        }
    }
}
