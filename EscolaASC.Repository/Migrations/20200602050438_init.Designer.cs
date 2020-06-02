﻿// <auto-generated />
using System;
using EscolaASC.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EscolaASC.Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200602050438_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("EscolaASC.Domain.Aluno", b =>
                {
                    b.Property<int>("Alunoid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeAluno");

                    b.Property<string>("Situacao");

                    b.HasKey("Alunoid");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("EscolaASC.Domain.Materia", b =>
                {
                    b.Property<int>("Materiaid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Media");

                    b.Property<string>("NomeMateria");

                    b.Property<int?>("Periodoid");

                    b.Property<string>("Situacao");

                    b.HasKey("Materiaid");

                    b.HasIndex("Periodoid");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("EscolaASC.Domain.Periodo", b =>
                {
                    b.Property<int>("Periodoid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomePeriodo");

                    b.Property<int>("QuantidadeAlunos");

                    b.Property<int>("QuantidadeTurmas");

                    b.HasKey("Periodoid");

                    b.ToTable("Periodos");
                });

            modelBuilder.Entity("EscolaASC.Domain.Prova", b =>
                {
                    b.Property<int>("Provaid")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Alunoid");

                    b.Property<int?>("Materiaid");

                    b.Property<decimal>("Nota");

                    b.Property<int>("Peso");

                    b.HasKey("Provaid");

                    b.HasIndex("Alunoid");

                    b.HasIndex("Materiaid");

                    b.ToTable("Prova");
                });

            modelBuilder.Entity("EscolaASC.Domain.Turma", b =>
                {
                    b.Property<int>("Turmaid")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Materiaid");

                    b.Property<string>("NomeTurma");

                    b.Property<int?>("Periodoid");

                    b.Property<int>("QuantidadeAluno");

                    b.HasKey("Turmaid");

                    b.HasIndex("Materiaid");

                    b.HasIndex("Periodoid");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("EscolaASC.Domain.TurmaAluno", b =>
                {
                    b.Property<int>("Turmaid");

                    b.Property<int>("Alunoid");

                    b.HasKey("Turmaid", "Alunoid");

                    b.HasIndex("Alunoid");

                    b.ToTable("TurmaAluno");
                });

            modelBuilder.Entity("EscolaASC.Domain.Materia", b =>
                {
                    b.HasOne("EscolaASC.Domain.Periodo")
                        .WithMany("Materias")
                        .HasForeignKey("Periodoid");
                });

            modelBuilder.Entity("EscolaASC.Domain.Prova", b =>
                {
                    b.HasOne("EscolaASC.Domain.Aluno")
                        .WithMany("Provas")
                        .HasForeignKey("Alunoid");

                    b.HasOne("EscolaASC.Domain.Materia")
                        .WithMany("Provas")
                        .HasForeignKey("Materiaid");
                });

            modelBuilder.Entity("EscolaASC.Domain.Turma", b =>
                {
                    b.HasOne("EscolaASC.Domain.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("Materiaid");

                    b.HasOne("EscolaASC.Domain.Periodo")
                        .WithMany("Turmas")
                        .HasForeignKey("Periodoid");
                });

            modelBuilder.Entity("EscolaASC.Domain.TurmaAluno", b =>
                {
                    b.HasOne("EscolaASC.Domain.Aluno", "Aluno")
                        .WithMany("TurmaAlunos")
                        .HasForeignKey("Alunoid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EscolaASC.Domain.Turma", "Turma")
                        .WithMany("TurmaAlunos")
                        .HasForeignKey("Turmaid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
