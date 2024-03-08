using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleado_Prueba.Entities
{
    [Table("Empleado")]
    public class Empleado
    {
        public int Id {get; set; }

        [MaxLength(50)]
        public string Usuario { get; set; }
        public string Nombre { get; set; } = string.Empty;  
        public string ApellidoPaterno {  get; set; } = string.Empty;

        public string ApellidoMaterno {  get; set; } = string.Empty;

        public string Telefono {  get; set; } = string.Empty;

        public string CorreoElectronico { get; set; } = string.Empty;
        
        public string Puesto { get; set;} = string.Empty;

        public string FechaIngreso { get; set; } = string.Empty;

        //TODO: Guardar Hash
        public string Password { get; set; } 
    }
}
