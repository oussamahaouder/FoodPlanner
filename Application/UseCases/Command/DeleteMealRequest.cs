using MediatR;

namespace TaskManagerApp.Application.UseCases.Command
{
    public class DeleteMealRequest : IRequest<Task>
    {
        public int MealId { get; set; }
    }
}
