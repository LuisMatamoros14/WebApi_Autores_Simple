using System.ComponentModel.DataAnnotations;

namespace WebApi_Autores.DTOs
{
    public class CredencialesUsuario
    {
        [Required(ErrorMessage = "El campo {0} es necesario")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
