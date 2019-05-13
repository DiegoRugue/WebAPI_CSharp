using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Contracts {
    public interface IDependenteRepository {
        Dependente Get(int id);
        List<Dependente> GetAll();
        void Post(Dependente dependente);
        void Put(Dependente dependente);
        void Delete(int id);
    }
}
