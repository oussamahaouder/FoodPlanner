using MediatR;
using TaskManagerApp.Models;

namespace TaskManagerApp.Application.UseCases.Queries
{
    public class GetAllIngredientsQuery : IRequest<List<Ingredient>>
    {
    }
}
