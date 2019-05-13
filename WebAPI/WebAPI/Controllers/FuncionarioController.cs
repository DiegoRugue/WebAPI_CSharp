using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository) {
            this._repository = funcionarioRepository;
        }

        // GET: api/Funcionario
        [HttpGet]
        public List<Funcionario> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Funcionario/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Funcionario
        [HttpPost]
        public void Post([FromBody] Funcionario funcionario)
        {
            try {
                _repository.Post(funcionario);
            } catch {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // PUT: api/Funcionario
        [HttpPut("{id}")]
        public void Put([FromBody] Funcionario funcionario)
        {
            try {
                _repository.Put(funcionario);
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
