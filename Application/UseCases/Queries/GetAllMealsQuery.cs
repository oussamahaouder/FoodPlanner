using MediatR;
using TaskManagerApp.Models;

namespace TaskManagerApp.Application.UseCases.Queries
{
    public class GetAllMealsQuery : IRequest<List<Meal>>
    {
    }
}
