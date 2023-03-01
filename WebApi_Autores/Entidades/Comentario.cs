using Microsoft.AspNetCore.Identity;

namespace WebApi_Autores.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public int LibroId { get; set; }
        //campo de navegacion
        public Libro Libro { get; set; }
        public string UsuarioId { get; set; }
        public IdentityUser Usuario { get; set; }
    }
}
