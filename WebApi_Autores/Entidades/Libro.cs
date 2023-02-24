using System.ComponentModel.DataAnnotations;

namespace WebApi_Autores.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        [StringLength(maximumLength:120)]
        [Required(ErrorMessage ="El campo {0} es necesario")]
        public string Titulo { get; set; }
        public List<Comentario> Comentarios { get; set; }

    }
}
