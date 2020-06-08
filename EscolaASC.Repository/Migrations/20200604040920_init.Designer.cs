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
    [Migration("20200604040920_init")]
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

                    b.Property<string>("NomeMateria");

                    b.Property<int?>("Periodoid");

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

                    b.Property<decimal>("Nota");

                    b.Property<int>("OrdemProva");

                    b.Property<int>("Peso");

                    b.Property<int?>("TurmaAlunoAlunoid");

                    b.Property<int?>("TurmaAlunoTurmaid");

                    b.HasKey("Provaid");

                    b.HasIndex("TurmaAlunoTurmaid", "TurmaAlunoAlunoid");

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

                    b.Property<decimal>("Media");

                    b.HasKey("Turmaid", "Alunoid");

                    b.HasIndex("Alunoid");

                    b.ToTable("TurmaAluno");
                });

            modelBuilder.Entity("EscolaASC.Domain.Materia", b =>
                {
                    b.HasOne("EscolaASC.Domain.Periodo")
                        .WithMany("Materias")
                        .HasForeignKey("Periodoid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EscolaASC.Domain.Prova", b =>
                {
                    b.HasOne("EscolaASC.Domain.TurmaAluno")
                        .WithMany("Provas")
                        .HasForeignKey("TurmaAlunoTurmaid", "TurmaAlunoAlunoid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EscolaASC.Domain.Turma", b =>
                {
                    b.HasOne("EscolaASC.Domain.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("Materiaid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EscolaASC.Domain.Periodo")
                        .WithMany("Turmas")
                        .HasForeignKey("Periodoid")
                        .OnDelete(DeleteBehavior.Cascade);
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