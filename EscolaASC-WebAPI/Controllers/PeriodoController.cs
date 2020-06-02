using Microsoft.AspNetCore.Mvc;
using EscolaASC.Repository;
using System.Threading.Tasks;
using EscolaASC.Domain;

namespace EscolaASC_WebAPI.Controllers
{
    [Route("api/periodo")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        public IEscolaASCRepository _repo { get; }
        public PeriodoController(IEscolaASCRepository repo)
        {
            _repo = repo;

        }

        //PERIODO

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllPeriodosAsync();
                return Ok(results);
                
            }
            catch (System.Exception)
            {
                throw;
                
            }

            
        }
        string msg="Cheguei aqui";

        [HttpGet("{Periodoid}")]
        public async Task<IActionResult> Get(int Periodoid)
        {
            try
            {
                
                var results = await _repo.GetPeriodoByIdAsync(Periodoid);
                return Ok(results);
                
            }
            catch (System.Exception)
            {
                throw;
                
            }

            
        }

        [HttpPost]
        public async Task<IActionResult> Post(Periodo model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/periodo/{model.Periodoid}", model);


                };
                
                
            }
            catch (System.Exception)
            {
                throw;
                
            }
            return BadRequest();

            
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Periodoid, Periodo model)
        {
            try
            {
                var periodo= await _repo.GetPeriodoByIdAsync(Periodoid);
                if (periodo==null) return NotFound();


                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/periodo/{model.Periodoid}", model);


                };
                
                
            }
            catch (System.Exception)
            {
                throw;
                
            }
            return BadRequest();

            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Periodoid)
        {
            try
            {
                var periodo= await _repo.GetPeriodoByIdAsync(Periodoid);
                if (periodo==null) return NotFound();


                _repo.Delete(periodo);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok();


                };
                
                
            }
            catch (System.Exception)
            {
                throw;
                
            }
            return BadRequest();

            
        }

    }
}