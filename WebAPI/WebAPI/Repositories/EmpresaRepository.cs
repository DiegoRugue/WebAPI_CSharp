using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Repositories {
    public class EmpresaRepository : BaseRepository, IEmpresaRepository {
        public EmpresaRepository(ApplicationContext context) : base(context) {
        }

        public Empresa Get(int id) {
            using (contexto) {
                var Id = new SqlParameter("@Id", id);
                var empresa = contexto.Empresas
                    .FromSql("EXEC GetEmpresa @Id", parameters: Id)
                    .FirstOrDefault();
                return empresa;
            }
        }

        public List<Empresa> GetAll() {
            using (contexto) {
                var empresa = contexto.Empresas
                    .FromSql("EXEC GetEmpresas")
                    .ToList();
                return empresa;
            }
        }

        public void Post(Empresa empresa) {
            using (contexto) {
                empresa.DataCadastro = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
                empresa.DataAlteracao = "";
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@RazaoSocial", empresa.RazaoSocial));
                parametros.Add(new SqlParameter("@DataCadastro", empresa.DataCadastro));
                parametros.Add(new SqlParameter("@DataAlteracao", empresa.DataAlteracao));
                parametros.Add(new SqlParameter("@CNPJ", empresa.CNPJ));
                contexto.Database.ExecuteSqlCommand("EXEC PostEmpresa @RazaoSocial, @DataCadastro, " +
                    "@DataAlteracao, @CNPJ", parametros);
                    
                }
            
            
        }

        public void Put(Empresa empresa) {
            using (contexto) {
                empresa.DataAlteracao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Id", empresa.Id));
                parametros.Add(new SqlParameter("@RazaoSocial", empresa.RazaoSocial));
                parametros.Add(new SqlParameter("@DataAlteracao", empresa.DataAlteracao));
                parametros.Add(new SqlParameter("@CNPJ", empresa.CNPJ));
                contexto.Database.ExecuteSqlCommand("EXEC PutEmpresa @Id, @RazaoSocial, " +
                    "@DataAlteracao, @CNPJ", parametros);
            }
        }

        public void Delete(int id) {
            using (contexto) {
                var pId = new SqlParameter("@Id", id);
                contexto.Database.ExecuteSqlCommand("EXEC DeleteEmpresa @Id", pId);
            }
        }
    }
}
