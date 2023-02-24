using System.ComponentModel.DataAnnotations;

namespace WebApi_Autores.DTOs
{
    public class AutorCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(maximumLength: 120)]
        public string Nombre { get; set; }
    }
}
