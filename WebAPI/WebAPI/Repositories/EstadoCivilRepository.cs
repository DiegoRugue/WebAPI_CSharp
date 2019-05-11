using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
                    .FirstOrDefault<EstadoCivil>();
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

        public void Post(EstadoCivil estadoCivil) {
            using (contexto) {
                var parametro = new SqlParameter("@Nome", estadoCivil.Nome);
                var novoEstado = contexto.Database
                    .ExecuteSqlCommand("EXEC PostEstadoCivil @Nome", parametro);  
            }
        }
        public void Put(EstadoCivil estadoCivil) {
            using (contexto) {
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Id", estadoCivil.Id));
                parametros.Add(new SqlParameter("@Nome", estadoCivil.Nome));

                var atualizaEstado = contexto.Database
                    .ExecuteSqlCommand("EXEC PutEstadoCivil @Id, @Nome", parametros);
            }
        }
        public void Delete(int id) {
            using (contexto) {
                var pId = new SqlParameter("@Id", id);
                var delEstado = contexto.Database
                    .ExecuteSqlCommand("EXEC DeleteEstadoCivil @Id", pId);
            }
        }
    }
}
