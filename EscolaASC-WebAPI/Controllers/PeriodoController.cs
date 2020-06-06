using Microsoft.AspNetCore.Mvc;
using EscolaASC.Repository;
using System.Threading.Tasks;
using EscolaASC.Domain;
using EscolaASC_WebAPI.DTOs;
using System.Linq;
using System.Collections.Generic;
using System;

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
        public  async Task<IActionResult> Post([FromBody]PeriodoDTO request )
        {
            try
            {
                // qtd aluno  criar os aluno, criar as turmas e associar eles a um periodo
               
                
                var listaMateria= new List<Materia>();
                var listaTurma = new List<Turma>();
                var random = new Random();

                //Criação de Matérias na quantidade recebida

                for (int m = 0; m < request.QuantidadeMaterias; m++)
                    {
                        Materia materia = new Materia();
                        var mt=(char)random.Next('A','Z');
                        materia.NomeMateria=mt.ToString();
                        listaMateria.Add(materia);
                        
                    }

                //Criação de Turma na quantidade recebida

                for (int i = 0; i < request.QuantidadeTurmas; i++)
                {
                    

                    Turma turma = new Turma();

                    var nt=(char)random.Next('A','Z');

                    turma.NomeTurma=nt.ToString();
                    // Pegar aleatoriamente uma materia de listaMateria
                    
                    var m=random.Next(0,request.QuantidadeMaterias-1);
                    turma.Materia= listaMateria[m];

                    

                    
                    

                    //Criação de Alunos na quantidade recebida

                    for (int j = 0; j < request.QuantidadeAlunos; j++)
                    {
                        Aluno aluno = new Aluno();
                        TurmaAluno turmaAluno =  new TurmaAluno();
                        var na=(char)random.Next('A','Z');
                        
                        aluno.NomeAluno=na.ToString();

                        var acumulaPeso=0;
                        
                        
                        
                        //cria 3 provas pro aluno
                        for (int k = 1; k < 4 ; k++)
                        {
                            
                            Prova prova = new Prova();
                            prova.Nota=random.Next(0,10);
                            prova.Peso=random.Next(1,3);
                            prova.OrdemProva=k;

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
                            provaFinal.Nota=random.Next(0,10);
                            provaFinal.Peso=1;

                            provaFinal.OrdemProva=4;

                            turmaAluno.Media = (turmaAluno.Media+provaFinal.Nota)/2;

                            turmaAluno.Provas.Add(provaFinal);
                        }

                        if (turmaAluno.Media <5)
                        {
                            aluno.Situacao="Reprovado";
                        }
                        if (turmaAluno.Media >=5)
                        {
                            aluno.Situacao="Aprovado";
                        }
                        turmaAluno.Aluno=aluno;
                        turmaAluno.Turma=turma;

                        aluno.TurmaAlunos.Add(turmaAluno);
                        turma.TurmaAlunos.Add(turmaAluno);
                        
                    }

                    listaTurma.Add(turma);

                    
                }

                Periodo periodo= new Periodo();
                periodo.Materias=listaMateria;
                periodo.Turmas=listaTurma;
                periodo.NomePeriodo=request.NomePeriodo;
                _repo.Add(periodo);


                await _repo.SaveChangesAsync();


            }
            catch (System.Exception e )  
            {
                throw e;
                
            }
            return Ok();

            
        }

        [HttpPut("{Periodoid}")]
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

        [HttpDelete("{Periodoid}")]
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

        




        //ALUNOS

    }
}