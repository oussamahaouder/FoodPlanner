using MediatR;
using TaskManagerApp.Infrastructure.Interfaces;
using TaskManagerApp.Models;

namespace TaskManagerApp.Application.UseCases.Queries
{
    public class GetIngredientByIdHandler(IFoodAdapter foodAdapter) : IRequestHandler<GetIngredientByIdQuery, string?>
    {
        private readonly IFoodAdapter _foodAdapter = foodAdapter;
        public async Task<string?> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
           return await _foodAdapter.GetIngredientById(request.Id);

        }
    }
}
