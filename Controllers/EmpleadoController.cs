using EmpresaApi.Model;
using EmpresaApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EmpresaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            var nuevoEmpleado = await _empleadoService.AddEmpleado(empleado);
            return CreatedAtAction(nameof(GetEmpleados), new { id = nuevoEmpleado.Id }, nuevoEmpleado);
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> GetEmpleados([FromQuery] string filtro, [FromQuery] int pagina = 1)
        {
            return await _empleadoService.GetEmpleados(filtro, pagina);
        }
    }
}
