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
    }
}
