using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Contracts {
    public interface IProfissaoRepository {
        Profissao Get(int id);
        List<Profissao> GetAll();
        void Post(Profissao profissao);
        void Put(Profissao profissao);
        void Delete(int id);
    }
}
