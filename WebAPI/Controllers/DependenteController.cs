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
            try {
                _repository.Post(dependente);
            } catch {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // PUT: api/Dependente/5
        [HttpPut("{id}")]
        public void Put([FromBody] Dependente dependente)
        {
            try {
                _repository.Put(dependente);
            } catch {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try {
                _repository.Delete(id);
            } catch {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}
