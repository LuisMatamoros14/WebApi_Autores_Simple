using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Autores.DTOs;
using WebApi_Autores.Entidades;
using WebApi_Autores.Filtros;

namespace WebApi_Autores.Controllers
{

    [ApiController]
    [Route("api/autores")]
    //Protegemos los endpoints a nivel controlador
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy ="EsAdmin")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet(Name ="obtenerAutores")]
        //[HttpGet("/listado")]
        //[HttpGet("listado")]
        //[ResponseCache(Duration=10)]
        //[ServiceFilter(typeof(MiFiltroDeAccion))]
        [AllowAnonymous]
        public async Task<ActionResult<List<AutorDTO>>> Get()
        {
            var autores = await context.Autores.ToListAsync();
            return mapper.Map<List<AutorDTO>>(autores);
        }

        //[HttpGet("{id:int}/{param2?}")]
        [HttpGet("{id:int}",Name ="obtenerAutor")]
        public async Task<ActionResult<AutorDTOConLibros>> Get(int id)
        {
            var autor = await context.Autores
                .Include(autorDB=>autorDB.AutoresLibros)
                .ThenInclude(libroDB=>libroDB.Libro)
                .FirstOrDefaultAsync(x=>x.Id== id);
            
            if(autor == null)
            {
                return NotFound();
            }

            return mapper.Map<AutorDTOConLibros>(autor);
        }

        [HttpGet("{nombre}", Name ="obtenerAutorPorNombre")]
        public async Task<ActionResult<List<AutorDTO>>> Get(string nombre)
        {
            var autores = await context.Autores.Where(x => x.Nombre.Contains(nombre)).ToListAsync();

            return mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpPost(Name ="crearAutor")]
        public async Task<ActionResult> Post([FromBody] AutorCreacionDTO autorCreacionDTO)
        {

            var autor = mapper.Map<Autor>(autorCreacionDTO);
            
            context.Add(autor);
            await context.SaveChangesAsync();

            var autorDTO = mapper.Map<AutorDTO>(autor);

            return CreatedAtRoute("ObtenerAutor", new { id = autor.Id }, autorDTO);
        }

        [HttpPut("{id:int}",Name ="actualizarAutor")]
        public async Task<ActionResult> Put(AutorCreacionDTO autorCreacionDTO, int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            var autor = mapper.Map<Autor>(autorCreacionDTO);
            autor.Id = id;

            context.Update(autor);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}",Name ="borrarAutor")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Autor(){ Id = id});

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
