using Microsoft.AspNetCore.Mvc;
using EscolaASC.Repository;
using System.Threading.Tasks;
using EscolaASC.Domain;
using EscolaASC_WebAPI.DTOs;
using System.Linq;
using System.Collections.Generic;

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
        public  async Task<IActionResult> Post( Configuration request )
        {
            try
            {
                // qtd aluno  criar os aluno, criar as turmas e associar eles a um periodo
               
                var acumulaPeso=0;
                var listaMateria= new List<Materia>();

                //Criação de Matérias na quantidade recebida

                for (int m = 0; m < request.QuantidadeMateria; m++)
                    {
                        Materia materia = new Materia();
                        materia.NomeMateria="";
                        listaMateria.Add(materia);
                        
                    }

                //Criação de Turma na quantidade recebida

                for (int i = 0; i < request.QuantidadeTurma; i++)
                {

                    Turma turma = new Turma();

                    turma.NomeTurma="";
                    // Pegar aleatoriamente uma materia de listaMateria
                    turma.Materia= null;
                    
                    

                    //Criação de Alunos na quantidade recebida

                    for (int j = 0; j < request.QuantidadeAluno; j++)
                    {
                        Aluno aluno = new Aluno();
                        TurmaAluno turmaAluno =  new TurmaAluno();
                        aluno.NomeAluno="";
                        
                        
                            //cria 3 provas pro aluno
                        for (int k = 1; k < 4 ; k++)
                        {
                            Prova prova = new Prova();
                            prova.Nota=0;
                            prova.Peso=0;

                            acumulaPeso +=prova.Peso;

                            turmaAluno.Provas.Add(prova);
                            
                            
                        }
                        //  média = ((Nota1*Peso1)+(Nota2*Peso2)+(Nota3*Peso3))/acumulaPeso

                        turmaAluno.Media= ((turmaAluno.Provas.First().Nota)*(turmaAluno.Provas.First().Peso)
                        +(turmaAluno.Provas.Skip(1).First().Nota)*(turmaAluno.Provas.Skip(1).First().Peso)
                        +(turmaAluno.Provas.Skip(2).First().Nota)*(turmaAluno.Provas.Skip(2).First().Peso))
                        /acumulaPeso;

                        

                        

                        
                        //testa se ele vai pra prova final

                        if (turmaAluno.Media>4 && turmaAluno.Media<6)
                        {
                            Prova provaFinal= new Prova();
                            provaFinal.Nota=0;
                            provaFinal.Peso=1;

                            turmaAluno.Media = (turmaAluno.Media+provaFinal.Nota)/2;
                        }

                        if (turmaAluno.Media <4)
                        {
                            aluno.Situacao="Reprovado";
                        }
                        if (turmaAluno.Media >6)
                        {
                            aluno.Situacao="Aprovado";
                        }


                        
                    }


                    
                }




            
                
            }
            catch (System.Exception)
            {
                throw;
                
            }
            return Ok();

            
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