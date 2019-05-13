using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Repositories {
    public class FuncionarioRepository : BaseRepository, IFuncionarioRepository {
        public FuncionarioRepository(ApplicationContext context) : base(context) {
        }

        public string Get(int id) {
            using (contexto) {
                string result = "";
                var Id = new SqlParameter("@Id", id);
                var funcionario = contexto.Funcionarios
                    .FromSql("EXEC GetFuncionario @Id", parameters: Id)
                    .FirstOrDefault();
                result = funcionario.ToString();

                var dependentes = contexto.Dependentes
                    .FromSql("EXEC GetDependentes")
                    .ToList();

                foreach (Dependente d in dependentes) {
                    if (d.IdFuncionario == id) {
                        result += d.ToString();
                    }
                }

                return result;
            }

        }

        public List<Funcionario> GetAll() {
            using (contexto) {
                var funcionarios = contexto.Funcionarios
                    .FromSql("EXEC GetFuncionarios")
                    .ToList();
                return funcionarios;
            }
        }

        public void Post(Funcionario funcionario) {
            using (contexto) {
                funcionario.DataCadastro = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
                funcionario.DataAlteracao = "";
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Nome", funcionario.Nome));
                parametros.Add(new SqlParameter("@CPF", funcionario.CPF));
                parametros.Add(new SqlParameter("@DataNascimento", funcionario.DataNascimento));
                parametros.Add(new SqlParameter("@Telefone", funcionario.Telefone));
                parametros.Add(new SqlParameter("@DataCadastro", funcionario.DataCadastro));
                parametros.Add(new SqlParameter("@DataAlteracao", funcionario.DataAlteracao));
                parametros.Add(new SqlParameter("@EnderecoRua", funcionario.EnderecoRua));
                parametros.Add(new SqlParameter("@EnderecoNumero", funcionario.EnderecoNumero));
                parametros.Add(new SqlParameter("@EnderecoBairro", funcionario.EnderecoBairro));
                parametros.Add(new SqlParameter("@EnderecoCidade", funcionario.EnderecoCidade));
                parametros.Add(new SqlParameter("@EnderecoEstado", funcionario.EnderecoEstado));
                parametros.Add(new SqlParameter("@EnderecoCep", funcionario.EnderecoCep));
                parametros.Add(new SqlParameter("@EnderecoComplemento", funcionario.EnderecoComplemento));
                parametros.Add(new SqlParameter("@IdProfissao", funcionario.IdProfissao));
                parametros.Add(new SqlParameter("@IdEmpresa", funcionario.IdEmpresa));
                parametros.Add(new SqlParameter("@IdEstadoCivil", funcionario.IdEstadoCivil));
                contexto.Database.ExecuteSqlCommand("EXEC PostFuncionario @Nome, @CPF, @DataNascimento, @Telefone, @DataCadastro, " +
                        "@DataAlteracao, @EnderecoRua, @EnderecoNumero, @EnderecoBairro, @EnderecoCidade, @EnderecoEstado, " +
                        "@EnderecoCep, @EnderecoComplemento, @IdProfissao, @IdEmpresa, @IdEstadoCivil", parametros);
            }
        }

        public void Put(Funcionario funcionario) {
            using (contexto) {
                funcionario.DataAlteracao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Id", funcionario.Id));
                parametros.Add(new SqlParameter("@Nome", funcionario.Nome));
                parametros.Add(new SqlParameter("@CPF", funcionario.CPF));
                parametros.Add(new SqlParameter("@DataNascimento", funcionario.DataNascimento));
                parametros.Add(new SqlParameter("@Telefone", funcionario.Telefone));
                parametros.Add(new SqlParameter("@DataAlteracao", funcionario.DataAlteracao));
                parametros.Add(new SqlParameter("@EnderecoRua", funcionario.EnderecoRua));
                parametros.Add(new SqlParameter("@EnderecoNumero", funcionario.EnderecoNumero));
                parametros.Add(new SqlParameter("@EnderecoBairro", funcionario.EnderecoBairro));
                parametros.Add(new SqlParameter("@EnderecoCidade", funcionario.EnderecoCidade));
                parametros.Add(new SqlParameter("@EnderecoEstado", funcionario.EnderecoEstado));
                parametros.Add(new SqlParameter("@EnderecoCep", funcionario.EnderecoCep));
                parametros.Add(new SqlParameter("@EnderecoComplemento", funcionario.EnderecoComplemento));
                parametros.Add(new SqlParameter("@IdProfissao", funcionario.IdProfissao));
                parametros.Add(new SqlParameter("@IdEmpresa", funcionario.IdEmpresa));
                parametros.Add(new SqlParameter("@IdEstadoCivil", funcionario.IdEstadoCivil));
                contexto.Database.ExecuteSqlCommand("EXEC PutFuncionario @Id @Nome, @CPF, @DataNascimento, @Telefone,@DataAlteracao, " +
                        "@EnderecoRua, @EnderecoNumero, @EnderecoBairro, @EnderecoCidade, @EnderecoEstado, " +
                        "@EnderecoCep, @EnderecoComplemento, @IdProfissao, @IdEmpresa, @IdEstadoCivil", parametros);
            }
        }

        public void Delete(int id) {
            using (contexto) {
                var pId = new SqlParameter("@Id", id);
                contexto.Database.ExecuteSqlCommand("EXEC DeleteFuncionario @Id", pId);
            }
        }
    }
}
