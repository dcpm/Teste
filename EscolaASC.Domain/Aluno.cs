using System.Collections.Generic;

namespace EscolaASC.Domain
{
    public class Aluno
    {
        public int Alunoid { get; set; }

        public string  NomeAluno { get; set; }

        

        //public List<Turma> Turmas { get; set; }

        //public string Turma { get; set; }

        

        public string Situacao { get; set; }

        public List<TurmaAluno> TurmaAlunos { get; set; }

    }
}