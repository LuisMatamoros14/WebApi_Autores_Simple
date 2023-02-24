namespace WebApi_Autores.DTOs
{
    public class AutorDTOConLibros : AutorDTO
    {
        public List<LibroDTO> Libros { get; set; }
    }
}
