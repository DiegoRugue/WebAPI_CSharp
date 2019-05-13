using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ParentescoController : ControllerBase {

        private readonly IParentescoRepository _repository;

        public ParentescoController(IParentescoRepository parentescoRepository) {
            _repository = parentescoRepository;
        }

        // GET: api/Parentesco
        [HttpGet]
        public List<Parentesco> Get() {
            return _repository.GetAll();
        }

        // GET: api/Parentesco/5
        [HttpGet("{id}")]
        public Parentesco Get(int id) {
            return _repository.Get(id);
        }

    }
}
