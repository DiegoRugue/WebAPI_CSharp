using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Repositories {
    public class ParentescoRepository : BaseRepository, IParentescoRepository {
        public ParentescoRepository(ApplicationContext context) : base(context) {
        }

       public Parentesco Get(int id) {
            using (contexto) {
                var Id = new SqlParameter("@Id", id);
                var parentesco = contexto.Parentescos
                    .FromSql("EXEC GetParentesco @Id", parameters: Id)
                    .FirstOrDefault();
                return parentesco;
            }
        }

        public List<Parentesco> GetAll() {
            using (contexto) {
                var parentescos = contexto.Parentescos
                    .FromSql("EXEC GetParentescos")
                    .ToList();
                return parentescos;
            }
        }

        public void Post(Parentesco parentesco) {
            using (contexto) {
                var parametro = new SqlParameter("@Nome", parentesco.Nome);
                var novoParentesco = contexto.Database
                    .ExecuteSqlCommand("EXEC PostParentesco @Nome", parametro);  
            }
        }
        public void Put(Parentesco parentesco) {
            using (contexto) {
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Id", parentesco.Id));
                parametros.Add(new SqlParameter("@Nome", parentesco.Nome));

                var atualizaParentesco = contexto.Database
                    .ExecuteSqlCommand("EXEC PutParentesco @Id, @Nome", parametros);
            }
        }
        public void Delete(int id) {
            using (contexto) {
                var pId = new SqlParameter("@Id", id);
                var delParentesco = contexto.Database
                    .ExecuteSqlCommand("EXEC DeleteParentesco @Id", pId);
            }
        }

    }
}
