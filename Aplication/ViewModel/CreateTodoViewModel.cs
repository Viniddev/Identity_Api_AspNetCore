using System.ComponentModel.DataAnnotations;

namespace IdentityApi.ViewModel
{
    public class CreateTodoViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
