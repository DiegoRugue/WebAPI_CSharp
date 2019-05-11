using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EstadoCivil> EstadosCivis { get; set; }
        public DbSet<Parentesco> Parentescos { get; set; }
    }
}
