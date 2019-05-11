using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCivilController : ControllerBase
    {

        private readonly IEstadoCivilRepository _repository;

        public EstadoCivilController(IEstadoCivilRepository estadoCivil)
        {
            _repository = estadoCivil;
        }

        // GET: api/EstadoCivil
        [HttpGet]
        public List<EstadoCivil> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/EstadoCivil/5
        [HttpGet("{id}")]
        public EstadoCivil Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/EstadoCivil
        [HttpPost]
        public void Post([FromBody] EstadoCivil estadoCivil)
        {
            _repository.Post(estadoCivil);
        }

        // PUT: api/EstadoCivil
        [HttpPut]
        public void Put([FromBody] EstadoCivil estadoCivil)
        {
            _repository.Put(estadoCivil);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
