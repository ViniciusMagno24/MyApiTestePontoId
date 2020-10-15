using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Models;

namespace WebApi.Infraestrutura.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Escola> Escolas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=Escolas;user=root;password=masterkey;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(c => c.CPF);
                entity.Property(c => c.DataNascimento).IsRequired();
                entity.Property(c => c.Nome).IsRequired();
                entity.Property(c => c.CodigoEscolar).IsRequired();
                entity.Property(c => c.TurmaId).IsRequired();
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Serie).IsRequired();
                entity.Property(c => c.Turno).IsRequired();
                entity.HasMany<Aluno>(c => c.Alunos).WithOne().HasForeignKey(c => c.TurmaId);
                entity.Ignore(c => c.Alunos);
            });

            modelBuilder.Entity<Escola>(entity =>
            {
                entity.HasKey(c => c.CodigoINEP);
                entity.Property(c => c.Nome).IsRequired();
                entity.HasMany<Turma>(c => c.Turmas).WithOne().HasForeignKey(c => c.CodigoEscolar);
                entity.Ignore(c => c.Turmas);
            });
        }
    }
}
