﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _repository;
        public EmpresaController(IEmpresaRepository empresaRepository) {
            this._repository = empresaRepository;
        }

        // GET: api/Empresa
        [HttpGet]
        public List<Empresa> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public Empresa Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Empresa
        [HttpPost]
        public void Post([FromBody] Empresa empresa)
        {
            try {
                _repository.Post(empresa);
            } catch {
                HttpContext.Response.StatusCode = 400;
            }
           
        }

        // PUT: api/Empresa
        [HttpPut]
        public void Put([FromBody] Empresa empresa)
        {
            try {
                _repository.Put(empresa);
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
