using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class EstadoCivilRepository : BaseRepository, IEstadoCivilRepository {
        public EstadoCivilRepository(ApplicationContext context) : base(context) {
        }

        public EstadoCivil Get(int id) {
            using (contexto) {
                var Id = new SqlParameter("@Id", id);
                var estadoCivil = contexto.EstadosCivis
                    .FromSql("EXEC GetEstadoCivil @Id", parameters: Id)
                    .FirstOrDefault();
                return estadoCivil;
            }
        }

        public List<EstadoCivil> GetAll() {
            using (contexto) {
                var estadosCivis = contexto.EstadosCivis
                    .FromSql("EXEC GetEstadosCivis")
                    .ToList();
                return estadosCivis;
            }
        }
    }
}
