using MediatR;
using TaskManagerApp.Infrastructure.Interfaces;

namespace TaskManagerApp.Application.UseCases.Command
{
    public class CreateIngredientHandler(IFoodAdapter foodAdapter) : IRequestHandler<CreateIngredientRequest, bool>
    {
        private readonly IFoodAdapter _foodAdapter = foodAdapter;
        public async Task<bool> Handle(CreateIngredientRequest request, CancellationToken cancellationToken)
        {
            var response = await _foodAdapter.AddIngredients(request.ingredients);
            return response;
        }
    }
}
