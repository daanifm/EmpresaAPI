using EmpresaApi.Data;
using EmpresaApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaApi.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly EmpresaDbContext _context;

        public EmpleadoService(EmpresaDbContext context)
        {
            _context = context;
        }

        public async Task<Empleado> AddEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<List<Empleado>> GetEmpleados(string filtro, int pagina)
        {
            int pageSize = 10;
            return await _context.Empleados
                .Where(e => string.IsNullOrEmpty(filtro) || e.Nombre.Contains(filtro))
                .Skip((pagina - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
