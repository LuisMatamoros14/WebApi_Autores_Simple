﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Autores.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage="El campo {0} es necesario")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [NotMapped]
        public int Edad { get; set; }
        public List<Libro> Libros { get; set; }
    }
}
