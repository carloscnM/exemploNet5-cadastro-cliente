using System.ComponentModel.DataAnnotations;

namespace Cliente.APP.Models
{
    public class CustomerViewModel 
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string CPF { get; set; }
    }
}
