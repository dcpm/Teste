using System.Threading.Tasks;
using EscolaASC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EscolaASC_WebAPI.Controllers
{
    [Route("api/periodo/turma")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly IEscolaASCRepository _repo;

        public TurmaController(IEscolaASCRepository repo)
        {
            _repo=repo;
            
        }

        //TURMAS

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllTurmasAsync(false);
                return Ok(results);
                
            }
            catch (System.Exception)
            {
                throw;
                
            }

            

            
        }

        [HttpGet("{Turmaid}")]
        public async Task<IActionResult> Get(int Turmaid)
        {
            try
            {
                
                var results = await _repo.GetTurmaByIdAsync(Turmaid, false);
                return Ok(results);
                
            }
            catch (System.Exception)
            {
                throw;
                
            }
        
       }

    }
}