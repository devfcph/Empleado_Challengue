using Empleado_Prueba.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data;

namespace Empleado_Prueba.Context
{
    public class EmpleadoContext :DbContext
    {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options) : base(options) 
        {
            
        }

        public DbSet<Empleado> EmpleadosDataSet { get; set; }
    }
}
