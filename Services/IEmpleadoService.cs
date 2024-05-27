using EmpresaApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpresaApi.Services
{
    public interface IEmpleadoService
    {
        Task<Empleado> AddEmpleado(Empleado empleado);
        Task<List<Empleado>> GetEmpleados(string filtro, int pagina);
    }
}
