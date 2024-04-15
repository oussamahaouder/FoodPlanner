using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
   
    }
}
        