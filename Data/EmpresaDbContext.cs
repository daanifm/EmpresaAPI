using EmpresaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmpresaApi.Data
{
    public class EmpresaDbContext : DbContext
    {
        public EmpresaDbContext(DbContextOptions<EmpresaDbContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
