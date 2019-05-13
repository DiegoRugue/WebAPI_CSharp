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
        public DbSet<Profissao> Profissoes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }

    }
}
