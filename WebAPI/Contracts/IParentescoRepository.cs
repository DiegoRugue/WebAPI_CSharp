using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Contracts {
    public interface IParentescoRepository {
        Parentesco Get(int id);
        List<Parentesco> GetAll();

    }
}
