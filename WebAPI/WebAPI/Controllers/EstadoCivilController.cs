using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCivilController : ControllerBase
    {
        private ApplicationContext contexto;
        public EstadoCivilController(ApplicationContext context)
        {
            this.contexto = context;
        }

        // GET: api/EstadoCivil
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EstadoCivil/5
        [HttpGet("{id}")]
        public List<EstadoCivil> Get(int id)
        {
            using (contexto)
            {
                var Id = new SqlParameter("@Id", id);
                var estadoCivil = contexto.EstadoCivils.
                    FromSql("EXEC GetEstadoCivil @Id", parameters: Id)
                    .ToList();
                return estadoCivil;
            } 
        }

        // POST: api/EstadoCivil
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/EstadoCivil/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
