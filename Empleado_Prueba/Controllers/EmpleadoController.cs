using Empleado_Prueba.Context;
using Empleado_Prueba.Entities;
using Empleado_Prueba.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Empleado_Prueba.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private readonly IEmpleado _service;

        public EmpleadoController( IEmpleado service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("find/{name}")]
        public async Task<ActionResult<List<Empleado>>> GetEmpleadosByName(string name)
        {
            try
            {
                //TO-DO: CALL SERVICE CLASS
                /*var empleados = await _context.EmpleadosDataSet.AllAsync( item => item.Equals(name));
                return Ok(empleados);
                */

                var empleados  = await _service.ObtenerEmpleadosPorNombre(name);

                return Ok(empleados);

            }
            catch (Exception e)
            {
                //return new BadRequest(new List<Empleado> { new Empleado() });
                return BadRequest(new List<Empleado> { new Empleado() });
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddEmpleado([FromBody] Empleado empleado)
        {
            try
            {

                await _service.AgregarEmpleado(empleado);

                return Ok("Empleado guardado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<Empleado>>> GetEmpleados()
        {
            try
            {
                return await _service.ObtenerEmpleados();
            }
            catch (Exception e)
            {
                return BadRequest("Not data");
            }

        }
    }
}
