using AutoMapper;
using WebApi_Autores.DTOs;
using WebApi_Autores.Entidades;

namespace WebApi_Autores.Utilidades
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<AutorCreacionDTO,Autor>();
            CreateMap<Autor, AutorDTO>();
            CreateMap<LibroCreacionDTO, Libro>();
            CreateMap<Libro, LibroDTO>();

        }
    }
}
