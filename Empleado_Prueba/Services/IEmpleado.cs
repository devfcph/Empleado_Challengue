using Empleado_Prueba.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Empleado_Prueba.Services
{
    public interface IEmpleado
    {
        public Task<ActionResult<Empleado>> AgregarEmpleado(Empleado empleado);

        public Task<ActionResult<List<Empleado>>> ObtenerEmpleadosPorNombre(string nombre);

        public Task<ActionResult<List<Empleado>>> ObtenerEmpleados();
    }
}
