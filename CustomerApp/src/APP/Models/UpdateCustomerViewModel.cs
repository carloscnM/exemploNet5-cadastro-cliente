using System.ComponentModel.DataAnnotations;
using CustomerApp.Models.ModelsValidations;

namespace CustomerApp.Models
{
    public class UpdateCustomerViewModel : CustomerViewModel
    {
       [Required]
       public string Id { get; set; }
    }
}
