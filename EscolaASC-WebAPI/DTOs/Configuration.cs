using EscolaASC.Domain;

namespace EscolaASC_WebAPI.DTOs
{
    public class Configuration
    {
        public int QuantidadeAluno { get; set; }

        public int QuantidadeTurma { get; set; }

        public int QuantidadeMateria { get; set; }

        public  Periodo Periodo { get; set; }
    }
}