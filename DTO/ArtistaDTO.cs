using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO
{
    public class ArtistaDTO
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre no pueda pasar los 50 digitos")]
        public string Name { get; set; }
        
    }
}