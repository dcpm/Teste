using System.Collections.Generic;

namespace EscolaASC.Domain
{
    public class Materia
    {
        public int Materiaid { get; set; }

        public string NomeMateria { get; set; }

        

        public string Situacao { get; set; }

        public List<Prova> Provas { get; set; }

        
    




        public int Media { get; set; }

    }
}