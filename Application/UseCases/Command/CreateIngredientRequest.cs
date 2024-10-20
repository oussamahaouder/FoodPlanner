using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskManagerApp.Models;

namespace TaskManagerApp.Application.UseCases.Command
{
    public class CreateIngredientRequest : IRequest<bool>
    {
        public List<Ingredient> ingredients { get; set; }
    }
}
