namespace EscolaASC.Domain
{
    public class TurmaAluno
    {
        public int Turmaid { get; set; }

        public Turma Turma { get; set; }

        public int Alunoid { get; set; }

        public Aluno Aluno { get; set; }

        
    }
}