using WebApi_Autores.Entidades;

namespace WebApi_Autores.DTOs
{
    public class AutorDTO : Recurso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
    }
}
