using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Repositories {
    public class ProfissaoRepository : BaseRepository, IProfissaoRepository {
        public ProfissaoRepository(ApplicationContext context) : base(context) {
        }
        public Profissao Get(int id) {
            using (contexto) {
                var Id = new SqlParameter("@Id", id);
                var profissao = contexto.Profissoes
                    .FromSql("EXEC GetProfissao @Id", parameters: Id)
                    .FirstOrDefault();
                return profissao;
            }
        }

        public List<Profissao> GetAll() {
            using (contexto) {
                var profissoes = contexto.Profissoes
                    .FromSql("EXEC GetProfissoes")
                    .ToList();
                return profissoes;
            }
        }

        public void Post(Profissao profissao) {
            using (contexto) {
                profissao.DataCadastro = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
                profissao.DataAlteracao = "";
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Nome", profissao.Nome));
                parametros.Add(new SqlParameter("@DataCadastro", profissao.DataCadastro));
                parametros.Add(new SqlParameter("@DataAlteracao", profissao.DataAlteracao));
                contexto.Database.ExecuteSqlCommand("EXEC PostProfissao @Nome, @DataCadastro, @DataAlteracao", parametros);
            }
        }

        public void Put(Profissao profissao) {
            using (contexto) {
                profissao.DataAlteracao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Id", profissao.Id));
                parametros.Add(new SqlParameter("@Nome", profissao.Nome));
                parametros.Add(new SqlParameter("@DataAlteracao", profissao.DataAlteracao));
                contexto.Database.ExecuteSqlCommand("EXEC PutProfissao @Id, @Nome, @DataAlteracao", parametros);
            }
        }

        public void Delete(int id) {
            using (contexto) {
                var pId = new SqlParameter("@Id", id);
                contexto.Database.ExecuteSqlCommand("EXEC DeleteProfissao @Id", pId);
            }
        }
    }
}
