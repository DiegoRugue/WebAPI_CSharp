using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Repositories {
    public class DependenteRepository : BaseRepository, IDependenteRepository {
        public DependenteRepository(ApplicationContext context) : base(context) {
        }

        public Dependente Get(int id) {
            using (contexto) {
                var Id = new SqlParameter("@Id", id);
                var dependente = contexto.Dependentes
                    .FromSql("EXEC GetDependente @Id", parameters: Id)
                    .FirstOrDefault();
                return dependente;
            }
        }

        public List<Dependente> GetAll() {
            using (contexto) {
                var dependentes = contexto.Dependentes
                    .FromSql("EXEC GetDependentes")
                    .ToList();
                return dependentes;
            }
        }

        public void Post(Dependente dependente) {
            using (contexto) {
                dependente.DataCadastro = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
                dependente.DataAlteracao = "";
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Nome", dependente.Nome));
                parametros.Add(new SqlParameter("@CPF", dependente.CPF));
                parametros.Add(new SqlParameter("@DataNascimento", dependente.DataNascimento));
                parametros.Add(new SqlParameter("@DataCadastro", dependente.DataCadastro));
                parametros.Add(new SqlParameter("@DataAlteracao", dependente.DataAlteracao));
                parametros.Add(new SqlParameter("@IdFuncionario", dependente.IdFuncionario));
                parametros.Add(new SqlParameter("@IdParentesco", dependente.IdParentesco));
                contexto.Database.ExecuteSqlCommand("EXEC PostDependente @Nome, @CPF, @DataNascimento, @DataCadastro, " +
                        "@DataAlteracao, @IdFuncionario, @IdParentesco", parametros);
            }
        }

        public void Put(Dependente dependente) {
            using (contexto) {
                dependente.DataAlteracao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Nome", dependente.Nome));
                parametros.Add(new SqlParameter("@CPF", dependente.CPF));
                parametros.Add(new SqlParameter("@DataNascimento", dependente.DataNascimento));
                parametros.Add(new SqlParameter("@DataAlteracao", dependente.DataAlteracao));
                parametros.Add(new SqlParameter("@IdFincionario", dependente.IdFuncionario));
                parametros.Add(new SqlParameter("@IdParentesco", dependente.IdParentesco));
                contexto.Database.ExecuteSqlCommand("EXEC PutDependente @Nome, @CPF, @DataNascimento, " +
                        "@DataAlteracao, @IdFuncionario, @IdParentesco", parametros);
            }
        }

        public void Delete(int id) {
            using (contexto) {
                var pId = new SqlParameter("@Id", id);
                contexto.Database.ExecuteSqlCommand("EXEC DeleteDependente @Id", pId);
            }
        }
    }
}
