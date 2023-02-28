using System.ComponentModel.DataAnnotations;

namespace WebApi_Autores.DTOs
{
    public class LibroCreacionDTO
    {
        [StringLength(maximumLength: 120)]
        [Required(ErrorMessage = "El campo {0} es necesario")]
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public List<int> AutoresIds { get; set; }
    }
}
