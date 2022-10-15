using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Servicios
{
    public class ArtistaService
    {
        // mandamos a llamar la conexiona  la base de datos
        private readonly chinookContext _context;
        private readonly ILogger<ArtistaService> _logger;
        // generamos un constructor para que inicialice el context y poder utilizarlo
        public ArtistaService(ILogger<ArtistaService> logger,chinookContext context)
        {
            _context = context;
            _logger = logger;
        }


        public List<Artist> getAllArtist(){
            return _context.Artists.ToList();
        }

        public Artist? getById(int id){
            // return _context.Artists.Where( query => query.Artists. = id).FirstOr;
            return _context.Artists.Where(query => query.ArtistId == id).FirstOrDefault();
        }





    }
}