using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class EstadoCivilRepository
    {
        private ApplicationContext contexto;
        public EstadoCivilRepository(ApplicationContext context)
        {
            this.contexto = context;
        }

        public void GetEstadoCivil(int id)
        {
            
        }
    }
}
