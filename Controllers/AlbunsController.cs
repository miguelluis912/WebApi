using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

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

        public AlbunsController(ArtistaService serviceArtista)
        {
            _artistaService = serviceArtista;
        }

        [HttpGet]
        public IActionResult getAllArtist()
        {
            try
            {
                return Ok(_artistaService.getAllArtist());
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getArtist(int id){
            Artist? artista = _artistaService.getById(id);

            if(artista is not null){
                return Ok(artista);
            }

            return NotFound( new { message = "elemento no encontrado", status = false});
        }

    }
}
