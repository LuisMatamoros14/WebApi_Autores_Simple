using WebApi_Autores.DTOs;

namespace WebApi_Autores.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO)
        {
            return queryable
                .Skip((paginacionDTO.Pagina - 1) * paginacionDTO.RecordsPorpagina)
                .Take(paginacionDTO.RecordsPorpagina);

        }
    }
}
