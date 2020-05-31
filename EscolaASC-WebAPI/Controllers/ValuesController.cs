using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaASC_WebAPI.Data;
using EscolaASC_WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaASC_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ValuesController : ControllerBase
    {
        public DataContext Context { get; }
        public ValuesController(DataContext context)
        {
            this.Context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await Context.Materias.ToListAsync();
                return Ok(results);
                
            }
            catch (System.Exception)
            {
                
                throw;
            }

            
        }

        // GET api/values/5
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            //FirstOrDefault(x => x.Materiaid == id);
            try
            {
                var results = await Context.Materias.FirstOrDefaultAsync(x => x.Materiaid == id);
                return Ok(results);
                
            }
            catch (System.Exception)
            {
                
                throw;
            }



        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
