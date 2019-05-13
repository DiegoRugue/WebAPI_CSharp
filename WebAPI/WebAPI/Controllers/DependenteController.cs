using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenteController : ControllerBase
    {
        private readonly IDependenteRepository _repository;
        public DependenteController(IDependenteRepository dependenteRepository) {
            this._repository = dependenteRepository;
        }

        // GET: api/Dependente
        [HttpGet]
        public List<Dependente> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Dependente/5
        [HttpGet("{id}")]
        public Dependente Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Dependente
        [HttpPost]
        public void Post([FromBody] Dependente dependente)
        {
            _repository.Post(dependente);
        }

        // PUT: api/Dependente/5
        [HttpPut("{id}")]
        public void Put([FromBody] Dependente dependente)
        {
            _repository.Put(dependente);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
