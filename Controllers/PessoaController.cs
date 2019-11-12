using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using netcore.example.webapi.basic.Domains.Models;
using netcore.example.webapi.basic.Domains.Services;

namespace netcore.example.webapi.basic.Controllers
{
    [ApiController]
    [Route("pessoas")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }
        [HttpPost]
        public void Post([FromBody] Pessoa pessoa)
        {
            pessoaService.Post(pessoa);
        }
        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return pessoaService.Get();
        }
        [HttpDelete("{id}")]
        public void Delete([FromRoute] string id)
        {
            pessoaService.Delete(Guid.Parse(id));
        }
        [HttpPut("{id}")]
        public void Put([FromRoute] string id, [FromBody] Pessoa pessoa)
        {
            pessoa.Id = Guid.Parse(id);
            pessoaService.Put(pessoa);
        }
    }
}
