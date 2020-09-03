using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pets.Domains;
using API_Pets.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDoPetController : ControllerBase
    {

        TipoDoPetRepository rep = new TipoDoPetRepository();

        // GET: api/<TipoDoPetController>
        [HttpGet]
        public List<TipoDoPet> Get()
        {
            return rep.ListarTodos();
        }

        // GET api/<TipoDoPetController>/5
        [HttpGet("{id}")]
        public TipoDoPet Get(int id)
        {
            return rep.BuscarId(id);
        }

        // POST api/<TipoDoPetController>
        [HttpPost]
        public TipoDoPet Post([FromBody] TipoDoPet t)
        {
            return rep.Adicionar(t);
        }

        // PUT api/<TipoDoPetController>/5
        [HttpPut("{id}")]
        public TipoDoPet Put(int id, [FromBody] TipoDoPet t)
        {
            return rep.Alterar(id, t);
        }

        // DELETE api/<TipoDoPetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Remover(id);
        }
    }
}
