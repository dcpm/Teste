using System.Collections.Generic;

namespace EscolaASC.Domain
{
    public class Periodo
    {
        public int Periodoid { get; set; }

        public string NomePeriodo { get; set; }

        public List<Materia> Materias { get; set; }

        public int QuantidadeTurmas { get; set; }

        public int QuantidadeAlunos { get; set; }

        public List<Turma> Turmas { get; set; }

    }
}