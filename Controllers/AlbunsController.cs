using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.DTO;

using WebApi.Servicios;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbunsController : ControllerBase
    {
        // invocamos en context de la base
        // private chinookContext _context;
        // // generamos un constructor para que inicialice el context y poder utilizarlo
        // public AlbunsController(chinookContext context)
        // {
        //     _context = context;
        // }

        // [HttpGet]
        // public async Task<IActionResult> Get()
        // {
        //     try
        //     {
        //         var listAlbum = await _context.Artists.ToListAsync();
        //         return Ok(listAlbum);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        // [HttpGet]
        // public IActionResult getAllArtist()
        // {

        // }

        // inyectamos el servicio  
        private readonly ArtistaService _artistaService;

        /* A constructor that is receiving a service and assigning it to a private variable. */
        public AlbunsController(ArtistaService serviceArtista)
        {
            _artistaService = serviceArtista;
        }

        [HttpGet]
        /// <summary>
        /// It returns a list of all the artists in the database
        /// </summary>
        /// <returns>
        /// A list of all the artists in the database.
        /// </returns>
        public IActionResult getAllArtist()
        {
            // protegemos el codigo para posibles errores en la persistencia de datos
            try
            {
                /* Returning a list of all the artists in the database. */
                return Ok(_artistaService.getAllArtist());
            }
            catch (Exception ex)
            {
                /* Returning a 400 status code and the error message. */
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        /// <summary>
        /// It returns the artist with the given id.
        /// </summary>
        /// <param name="id">The id of the artist you want to get.</param>
        public IActionResult getArtist(int id)
        {
            /* Checking if the artist exists. */
            Artist? artista = _artistaService.getById(id);

            /* Checking if the artist exists. */
            if(artista is not null){
                return Ok(artista);
            }

            /* Returning a 404 status code and a message. */
            return NotFound( new { message = "elemento no encontrado", status = 404});
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        /// <summary>
        /// This function receives a JSON object from the client, converts it to a C# object, and saves
        /// it to the database.
        /// </summary>
        /// <param name="ArtistaDTO">The object that will be sent to the server.</param>
        public IActionResult saveArtist([FromBody] ArtistaDTO artistaDTO)
        {
            /* Checking if the model is valid. */
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            /* Saving the artistaDTO object in the database. */
            bool resultado = _artistaService.saveArtistista(artistaDTO);

            /* Returning a 201 status code and a message. */
            if(resultado){
                return Created("/artista", new {message = "Se creo correctamente", status = 201});
            }
            /* Returning a 500 status code and a message. */
            return Problem(null,null,(int)HttpStatusCode.InternalServerError, "Se presento un problema el guardar el recurso");
        }


        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        /// <summary>
        /// This function updates an artista in the database.
        /// </summary>
        /// <param name="ArtistaDTO">The object that will be sent to the API.</param>
        /// <param name="id">The id of the artist you want to update.</param>
        public IActionResult updateArtista([FromBody] ArtistaDTO artistaDTO, int id){
            /* Checking if the model is valid. */
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            /* Updating the artistaDTO object in the database. */
            bool resultado = _artistaService.updateArtista(artistaDTO, id);

            /* Returning a 200 status code and a message. */
            if(resultado){
                return Ok(new {message = $"Se aactualizo correctamente el recurso {id}", status = 201});
            }
            /* Returning a 500 status code and a message. */
            return Problem(null,null,(int)HttpStatusCode.InternalServerError, "Se presento un problema el actualizar el recurso");

        }

        [HttpDelete]
        [Produces("application/json")]

        /// <summary>
        /// It deletes an artist from the database.
        /// </summary>
        /// <param name="id">The id of the artist to delete</param>
        public IActionResult deleteArtista( int id){
            /* Calling the deleteArtista function in the ArtistaService class. */
            bool respuesta = _artistaService.deleteArtista( id );
            /* Returning a 200 status code and a message. */
            if(respuesta){
                return Ok(new {message = $"Se elimino correctamente el recurso {id}", status = 201});
            }
            /* Returning a 500 status code and a message. */
            return Problem(null,null,(int)HttpStatusCode.InternalServerError, "Se presento un problema al tratar de eliminar el recurso");
        }
    }
}
