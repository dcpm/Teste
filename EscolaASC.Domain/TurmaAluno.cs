using System.Collections.Generic;

namespace EscolaASC.Domain
{
    public class TurmaAluno
    {

        public TurmaAluno()
        {
            this.Provas=new List<Prova>();
            

        }
        public int Turmaid { get; set; }

        public Turma Turma { get; set; }

        public int Alunoid { get; set; }

        public Aluno Aluno { get; set; }

        public decimal Media { get; set; }

        public List<Prova> Provas { get; set; }

        
    }
}