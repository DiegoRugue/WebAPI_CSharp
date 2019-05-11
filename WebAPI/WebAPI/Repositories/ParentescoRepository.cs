using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories {
    public class ParentescoRepository : BaseRepository, IParentescoRepository {
        public ParentescoRepository(ApplicationContext context) : base(context) {
        }

       public Parentesco Get(int id) {
            using (contexto) {
                var Id = new SqlParameter("@Id", id);
                var Parentesco = contexto.Parentescos
                    .FromSql("EXEC GetParentesco @Id", parameters: Id)
                    .FirstOrDefault<Parentesco>();
                return Parentesco;
            }
        }

        public List<Parentesco> GetAll() {
            using (contexto) {
                var Parentescos = contexto.Parentescos
                    .FromSql("EXEC GetParentescos")
                    .ToList();
                return Parentescos;
            }
        }

        public void Post(Parentesco Parentesco) {
            using (contexto) {
                var parametro = new SqlParameter("@Nome", Parentesco.Nome);
                var novoParentesco = contexto.Database
                    .ExecuteSqlCommand("EXEC PostParentesco @Nome", parametro);  
            }
        }
        public void Put(Parentesco Parentesco) {
            using (contexto) {
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Id", Parentesco.Id));
                parametros.Add(new SqlParameter("@Nome", Parentesco.Nome));

                var atualizaEstado = contexto.Database
                    .ExecuteSqlCommand("EXEC PutParentesco @Id, @Nome", parametros);
            }
        }
        public void Delete(int id) {
            using (contexto) {
                var pId = new SqlParameter("@Id", id);
                var delEstado = contexto.Database
                    .ExecuteSqlCommand("EXEC DeleteParentesco @Id", pId);
            }
        }

    }
}
