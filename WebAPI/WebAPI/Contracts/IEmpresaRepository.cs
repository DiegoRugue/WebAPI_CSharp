using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Contracts {
    public interface IEmpresaRepository {
        Empresa Get(int id);
        List<Empresa> GetAll();
        void Post(Empresa empresa);
        void Put(Empresa empresa);
        void Delete(int id);
    }
}
