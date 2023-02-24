using System.ComponentModel.DataAnnotations;

namespace WebApi_Autores.DTOs
{
    public class LibroDTO
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 120)]
        [Required(ErrorMessage = "El campo {0} es necesario")]
        public string Titulo { get; set; }
        public List<ComentarioDTO> Comentarios { get; set; }
        public List<AutorDTO> Autores { get; set; }
    }
}
