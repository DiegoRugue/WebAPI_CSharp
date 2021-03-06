﻿using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories {
    public interface IEstadoCivilRepository {
        EstadoCivil Get(int id);
        List<EstadoCivil> GetAll();
        void Post(EstadoCivil estadoCivil);
        void Put(EstadoCivil estadoCivil);
        void Delete(int id);
    }
}