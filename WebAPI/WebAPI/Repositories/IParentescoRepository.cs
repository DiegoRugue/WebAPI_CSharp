using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories {
    public interface IParentescoRepository {
        Parentesco Get(int id);
        List<Parentesco> GetAll();
        void Post(Parentesco estadoCivil);
        void Put(Parentesco estadoCivil);
        void Delete(int id);
    }
}
