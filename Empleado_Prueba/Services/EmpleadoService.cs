using Empleado_Prueba.Context;
using Empleado_Prueba.Entities;
using Empleado_Prueba.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Empleado_Prueba.Services
{
    public class EmpleadoService : IEmpleado
    {

        private readonly EmpleadoContext _context;

        public EmpleadoService(EmpleadoContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Empleado>> AgregarEmpleado(Empleado empleado)
        {
            try
            {
                if (!EmpleadoValidaciones.isEntityValid(empleado))
                    throw new Exception("Información incorrecta, valide sus datos");


                if (!EmpleadoValidaciones.isTelefonoValid(empleado.Telefono))
                    throw new Exception("El teléfono no es válido");

                if (!EmpleadoValidaciones.isCorreoElectronicoValid(empleado.CorreoElectronico))
                    throw new Exception("El email no es válido");

                if (!EmpleadoValidaciones.isFechaIngresoValid(empleado.FechaIngreso))
                    throw new Exception("Fecha de ingreso no válida");

                empleado.Password = Cryptography.HashString(empleado.Password);

                await _context.EmpleadosDataSet.AddAsync(empleado);

                await _context.SaveChangesAsync();

                return empleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<ActionResult<List<Empleado>>> ObtenerEmpleados()
        {
            try
            {
                var empleados = await _context.EmpleadosDataSet.ToListAsync();
                return empleados;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<ActionResult<List<Empleado>>> ObtenerEmpleadosPorNombre(string nombre)
        {
            try
            {
                //var empleados = await _context.EmpleadosDataSet.AllAsync(item => item.Nombre.ToLower().Equals(nombre.ToLower()));
                List<Empleado> empleadosListaFinal = new List<Empleado>();
                var empl = await _context.EmpleadosDataSet.ToListAsync();

                empleadosListaFinal = empl.Where(item => item.Nombre.ToLower().Equals(nombre.ToLower())).ToList();

                return empleadosListaFinal;
            }
            catch(Exception e)
            {
                throw e;
            }
        }



    }
}
