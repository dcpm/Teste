using System.Linq;
using EscolaASC.Domain;
using Microsoft.EntityFrameworkCore;

namespace EscolaASC.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Materia> Materias { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Prova> Provas { get; set; }

        public DbSet<Prova> TurmaAluno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
        .SelectMany(t => t.GetForeignKeys())
        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior != DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Cascade;

            modelBuilder.Entity<TurmaAluno>().HasKey(PE => new { PE.Turmaid, PE.Alunoid });

        }



    }
}