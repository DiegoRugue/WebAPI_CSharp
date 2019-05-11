using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Contracts {
    public interface IParentescoRepository {
        Parentesco Get(int id);
        List<Parentesco> GetAll();
        void Post(Parentesco parentesco);
        void Put(Parentesco parentesco);
        void Delete(int id);
    }
}
