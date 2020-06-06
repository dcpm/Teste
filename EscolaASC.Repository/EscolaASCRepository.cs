using System.Linq;
using System.Threading.Tasks;
using EscolaASC.Domain;
using Microsoft.EntityFrameworkCore;

namespace EscolaASC.Repository
{
    public class EscolaASCRepository : IEscolaASCRepository
    {
        private readonly DataContext _context;

        public EscolaASCRepository(DataContext context)
        {
            this._context = context;


        }

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()>0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        //MATERIAS

        public Task<Materia[]> GetAllMateriasAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Materia> GetMateriaByAlunoAsync(int Alunoid)
        {
            throw new System.NotImplementedException();
        }

        public Task<Materia> GetMateriaByIdAsync(int Materiaid)
        {
            throw new System.NotImplementedException();
        }

        //PERIODOS

        public async Task<Periodo[]> GetAllPeriodosAsync()
        {
            IQueryable<Periodo>query =_context.Periodos
            .Include(c => c.Materias )
            .Include(c => c.Turmas);

            return await query.ToArrayAsync();
        }

        public async Task<Periodo> GetPeriodoByIdAsync(int Periodoid)
        {
            IQueryable<Periodo>query =_context.Periodos
            .Include(c => c.Materias )
            .Include(c => c.Turmas);
            
            query=query.AsNoTracking().Where(c => c.Periodoid==Periodoid);
            

            return await query.FirstOrDefaultAsync();
        }

        //PROVAS

        public Task<Prova[]> GetAllProvasByMateriaAsync(int Materiaid)
        {
            throw new System.NotImplementedException();
        }
        public Task<Prova> GetProvaByIdAsync(int Provaid)
        {
            throw new System.NotImplementedException();
        }

        //TURMAS

        public async Task<Turma[]> GetAllTurmasAsync(bool includeAluno=false)
        {
            IQueryable<Turma>query =_context.Turmas
            .Include(c => c.Materia );
            if (includeAluno)
            {
                query=query
                .Include(ta => ta.TurmaAlunos)
                .ThenInclude(a => a.Aluno);
            }
            query=query.AsNoTracking();
            

            return await query.ToArrayAsync();
        }

        public async Task<Turma> GetTurmaByIdAsync(int Turmaid, bool includeAluno=false)
        {
            IQueryable<Turma>query =_context.Turmas
            .Include(c => c.Materia);
            if (includeAluno)
            {
                query=query
                .Include(ta => ta.TurmaAlunos)
                .ThenInclude(a => a.Aluno);
            }
            query=query.AsNoTracking().Where(c => c.Turmaid==Turmaid);
            

            return await query.FirstOrDefaultAsync();
        }

        //ALUNOS

        public async Task<Aluno> GetAlunoByIdAsync(int Alunoid, bool includeTurma=false)
        {
            IQueryable<Aluno>query =_context.Alunos
            ;
            if (includeTurma)
            {
                query=query
                .Include(ta => ta.TurmaAlunos)
                .ThenInclude(a => a.Provas);

                query=query
                .Include(ta => ta.TurmaAlunos)
                .ThenInclude(a => a.Turma);

                
                
            }
            query=query.AsNoTracking().Where(c => c.Alunoid==Alunoid);
            

            return await query.FirstOrDefaultAsync();
        }




        //ACHO Q NÃO VOU USAR

        public async Task<Aluno> GetAlunoByTurmaAsync(string NomeTurma, bool includeTurma=false)
        {
            IQueryable<Aluno>query =_context.Alunos
            ;
            if (includeTurma)
            {
                query=query
                .Include(ta => ta.TurmaAlunos)
                .ThenInclude(a => a.Turma);
            }
            

            
            

            return await query.FirstOrDefaultAsync();
        }

    



       
    }
}