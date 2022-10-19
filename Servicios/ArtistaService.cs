using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.DTO;

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


    /// <summary>
    /// It returns a list of all the artists in the database
    /// </summary>
    /// <returns>
    /// A list of all the artists in the database.
    /// </returns>
        public List<Artist> getAllArtist(){
            return _context.Artists.ToList();
        }

        /// <summary>
        /// It returns the first artist in the database with the id that matches the id passed in as a
        /// parameter.
        /// </summary>
        /// <param name="id">The id of the artist you want to get</param>
        /// <returns>
        /// The first Artist object that matches the query.
        /// </returns>
        public Artist? getById(int id){
            // Se utiliza LINQ para realizar consultas a la bd
            return _context.Artists.Where(query => query.ArtistId == id).FirstOrDefault();
        }

        /// <summary>
        /// It saves an artist to the database.
        /// </summary>
        /// <param name="ArtistaDTO">is a class that contains the data that will be saved in the
        /// database.</param>
        /// <returns>
        /// A boolean value.
        /// </returns>
        public Boolean saveArtistista(ArtistaDTO artistaDTO){
            // creamos una instancia de tipo Artist
            Artist artista = new Artist();
            // asignamos el valor al DTO con el valor del modelo
            artista.Name = artistaDTO.Name;
            // variable de paso, para controlar la accion de guardado
            bool isSave = false;
            // variable de inicio de la transaccion a la base de datos
            var transaction = _context.Database.BeginTransaction();
            // protegemos el codigo para posibles errores en la persistencia de datos
            try
            {
               _context.Add(artista);       // preparamos el dato de la instancia
                _context.SaveChanges();     // persistimos los datos a la bd
                transaction.Commit();       // guardamos el commit de la transaccion
                isSave = true;              // cambiamos el valor de la variable de paso, En este punto paso correctamente el guardado.
            }
            catch (Exception e)
            {
                transaction.Rollback();         // si ocurre un error se realiza el rollback de los cambios en la bd
                _logger.LogError("Error:", e);  // pintamos en consola el error
                _logger.LogError(e.Message);    // pintamos en consola el error
                isSave = false;                 // cambiamos el valor de la variable de paso, En este punto ocurrio un problema en el guardado.
            }
            // retornamos el valor de la variable de pasa
            // true :: paso correctamente
            // false:: ocurrio algun problema
            return isSave;  

        }

        /// <summary>
        /// It updates an artist in the database.
        /// </summary>
        /// <param name="ArtistaDTO">It's a class that contains the data that I want to update.</param>
        /// <param name="id">The id of the artist to be updated.</param>
        /// <returns>
        /// A boolean value.
        /// </returns>
        public Boolean updateArtista(ArtistaDTO artistaDTO, int id){
            // variable de paso, para controlar la accion de actualizar
            bool isUpdate = false;
            // variable de inicio de la transaccion a la base de datos
            var transaction = _context.Database.BeginTransaction();
            // protegemos el codigo para posibles errores en la persistencia de datos
            try
            {
                // Se utiliza LINQ para realizar consultas a la bd
                // La linea de abajo se busca al artista por medio de su identificador ( id )
                Artist? artista = _context.Artists.Where(a => a.ArtistId == id).FirstOrDefault();
                // condicion para verificar que exista el rejistro
                if(artista is not null){
                    // asignamos el valor al DTO con el valor del modelo
                    artista.Name = artistaDTO.Name;     // asignamos el valor al DTO con el valor del modelo
                    _context.SaveChanges();             // preparamos el dato de la instancia
                    transaction.Commit();               // guardamos el commit de la transaccion
                    isUpdate = true;                    // cambiamos el valor de la variable de paso, En este punto paso correctamente el guardado.
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();         // si ocurre un error se realiza el rollback de los cambios en la bd
                _logger.LogError("Error:", e);  // pintamos en consola el error
                _logger.LogError(e.Message);    // pintamos en consola el error
                isUpdate = false;                 // cambiamos el valor de la variable de paso, En este punto ocurrio un problema en el guardado.
            }
            // retornamos el valor de la variable de pasa
            // true :: paso correctamente
            // false:: ocurrio algun problema
            return isUpdate;
        }

        /// <summary>
        /// It deletes an artist from the database.
        /// </summary>
        /// <param name="id">The id of the artist to delete.</param>
        /// <returns>
        /// A boolean value.
        /// </returns>
        public bool deleteArtista( int id ){
            // variable de paso, para controlar la accion de eliminar
            bool isDelete = false;
            // variable de inicio de la transaccion a la base de datos
            var transaction = _context.Database.BeginTransaction();
            // protegemos el codigo para posibles errores en la persistencia de datos
            try
            {
                // Se utiliza LINQ para realizar consultas a la bd
                // La linea de abajo se busca al artista por medio de su identificador ( id )
                Artist? artista = _context.Artists.Where(a => a.ArtistId == id).FirstOrDefault();
                // condicion para verificar que exista el rejistro
                if(artista is not null){
                    _context.Artists.Remove(artista);   // se prepara la eliminacion, Pasando el registro
                    _context.SaveChanges();             // se guardan los cambios de la eliminacion.
                    transaction.Commit();               // guardamos el commit de la transaccion
                    isDelete = true;                    // cambiamos el valor de la variable de paso, En este punto paso correctamente la eliminacion.
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();         // si ocurre un error se realiza el rollback de los cambios en la bd
                _logger.LogError("Error:", e);  // pintamos en consola el error
                _logger.LogError(e.Message);    // pintamos en consola el error
                isDelete = false;                 // cambiamos el valor de la variable de paso, En este punto ocurrio un problema en el guardado.
            }
            // retornamos el valor de la variable de pasa
            // true :: paso correctamente
            // false:: ocurrio algun problema
            return isDelete;
        }

    }
}