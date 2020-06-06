using System.Threading.Tasks;
using EscolaASC.Domain;

namespace EscolaASC.Repository
{
    public interface IEscolaASCRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //Periodo

        Task<Periodo[]> GetAllPeriodosAsync();

        Task<Periodo> GetPeriodoByIdAsync(int Periodoid);

        //Turma

        Task<Turma[]> GetAllTurmasAsync(bool includeAluno);

        Task<Turma> GetTurmaByIdAsync(int Turmaid, bool includeAluno);

        //Aluno

        Task<Aluno> GetAlunoByTurmaAsync(string NomeTurma, bool includeTurma);
        Task<Aluno> GetAlunoByIdAsync(int Alunoid, bool includeTurma);

        //Materia

        Task<Materia[]> GetAllMateriasAsync();

        Task<Materia> GetMateriaByIdAsync(int Materiaid);

        Task<Materia> GetMateriaByAlunoAsync(int Alunoid);


        

        //Prova

        Task<Prova> GetProvaByIdAsync(int Provaid);

        //Task<Prova[]> GetAllProvasByAlunoAsync(int Alunoid);

        Task<Prova[]> GetAllProvasByMateriaAsync(int Materiaid);




    }
}