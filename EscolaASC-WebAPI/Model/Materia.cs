using System.Collections.Generic;

namespace EscolaASC_WebAPI.Model
{
    public class Materia
    {
        public int Materiaid { get; set; }

        public string nome { get; set; }

        public int peso1 { get; set; }

        public int peso2 { get; set; }

        public int peso3 { get; set; }

        public IEnumerable<Prova> provas { get; set; }

        public int media { get; set; }

        public string situacao { get; set; }
        
    }
}