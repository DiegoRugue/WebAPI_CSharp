using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissaoController : ControllerBase
    {
        private readonly IProfissaoRepository _repository;
        public ProfissaoController(IProfissaoRepository profissaoRepository) {
            this._repository = profissaoRepository;
        }

        // GET: api/Profissao
        [HttpGet]
        public List<Profissao> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Profissao/5
        [HttpGet("{id}")]
        public Profissao Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Profissao
        [HttpPost]
        public void Post([FromBody] Profissao profissao)
        {
            try {
                _repository.Post(profissao);
            } catch {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // PUT: api/Profissao
        [HttpPut]
        public void Put([FromBody] Profissao profissao)
        {
            try {
                _repository.Put(profissao);
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
