using System.Collections.Generic;

namespace EscolaASC.Domain
{
    public class Turma
    {

        public Turma()
        {
            this.TurmaAlunos= new List<TurmaAluno>();
            
        }
        public int Turmaid { get; private set; }

        public string NomeTurma { get; set; }

        public Materia Materia { get;  set;}
        

        public List<TurmaAluno> TurmaAlunos { get; set; }

        public int QuantidadeAluno { get; set; }

    }
}