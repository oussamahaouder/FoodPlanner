using MediatR;
using TaskManagerApp.Models;

namespace TaskManagerApp.Application.UseCases.Queries
{
    public class GetIngredientByIdQuery : IRequest<string?>
    {
        public int Id { get; set; } 
    }
}
