using EscolaASC_WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EscolaASC_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options){}

        public DbSet<Materia> Materias { get; set; }
        

        
    }
}