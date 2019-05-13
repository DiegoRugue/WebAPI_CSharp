using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Contracts {
    public interface IFuncionarioRepository {
        string Get(int id);
        List<Funcionario> GetAll();
        void Post(Funcionario funcionario);
        void Put(Funcionario funcionario);
        void Delete(int id);
    }
}
