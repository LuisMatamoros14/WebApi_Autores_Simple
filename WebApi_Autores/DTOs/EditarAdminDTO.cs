using System.ComponentModel.DataAnnotations;

namespace WebApi_Autores.DTOs
{
    public class EditarAdminDTO
    {
        [Required(ErrorMessage = "El campo {0} es necesario")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
