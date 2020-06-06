using EscolaASC.Domain;

namespace EscolaASC_WebAPI.DTOs
{
    

    public class PeriodoDTO
    {
        public int QuantidadeAlunos { get; set; }

        public int QuantidadeTurmas { get; set; }

        public int QuantidadeMaterias { get; set; }

        public  Periodo Periodo { get; set; }

        public string  NomePeriodo { get; set; }
    }


    
}