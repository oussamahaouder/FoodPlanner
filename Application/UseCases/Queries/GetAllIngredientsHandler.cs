using MediatR;
using TaskManagerApp.Domain.Interfaces;
using TaskManagerApp.Infrastructure.Adapters;
using TaskManagerApp.Infrastructure.Interfaces;
using TaskManagerApp.Models;

namespace TaskManagerApp.Application.UseCases.Queries
{
    public class GetAllIngredientsHandler(IFoodService foodService) : IRequestHandler<GetAllIngredientsQuery, List<Ingredient>>
    {
        private readonly IFoodService _foodAdapter = foodService;
        public async Task<List<Ingredient>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _foodAdapter.GetIngredientsAsync();
        }
    }
}
