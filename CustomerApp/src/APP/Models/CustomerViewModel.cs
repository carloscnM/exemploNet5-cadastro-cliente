using System.ComponentModel.DataAnnotations;
using CustomerApp.Models.ModelsValidations;

namespace CustomerApp.Models
{
    public class CustomerViewModel 
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, CPFValid]
        public string CPF { get; set; }
    }
}
