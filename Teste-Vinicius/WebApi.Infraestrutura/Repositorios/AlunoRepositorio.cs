using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Dominio.Interfaces;
using WebApi.Dominio.Models;
using WebApi.Infraestrutura.Data;

namespace WebApi.Infraestrutura.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        DataContext _dataContext;
        public AlunoRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Criar(Aluno aluno)
        {
            _dataContext.Database.EnsureCreated();
            _dataContext.Alunos.Add(aluno);
            _dataContext.SaveChanges();
        }

        public void Atualizar(Aluno aluno)
        {
            _dataContext.Database.EnsureCreated();
            _dataContext.Update<Aluno>(aluno);
            _dataContext.SaveChanges();
        }

        public List<Aluno> ObterPorCodigoINEP(string codigo)
        {
            _dataContext.Database.EnsureCreated();
            List<Aluno> alunos = new List<Aluno>();

            alunos = _dataContext.Alunos.Where(c => c.CodigoEscolar == codigo).AsNoTracking().ToList();
            if (alunos.Count == 0)
                throw new Exception("Nenhum aluno Encontrado");

            return alunos;
        }

        public Aluno ObterPorId(string cpf)
        {
            _dataContext.Database.EnsureCreated();
            Aluno aluno = new Aluno();

            aluno = _dataContext.Alunos.Where(c => c.CPF == cpf).AsNoTracking().FirstOrDefault();
            if (aluno == null || aluno.CPF == null)
                throw new Exception("Nenhum aluno Encontrado");

            return aluno;
        }

        public List<Aluno> ObterPorTurmaId(int turmaId)
        {
            _dataContext.Database.EnsureCreated();
            List<Aluno> alunos = new List<Aluno>();

            alunos = _dataContext.Alunos.Where(c => c.TurmaId == turmaId).AsNoTracking().ToList();
            if (alunos.Count == 0)
                throw new Exception("Nenhum aluno Encontrado");

            return alunos;
        }

        public List<Aluno> ObterTodos()
        {
            _dataContext.Database.EnsureCreated();
            List<Aluno> alunos = new List<Aluno>();
            alunos = _dataContext.Alunos.AsNoTracking().ToList();
            if (alunos.Count == 0)
                throw new Exception("Nenhum aluno Cadastrado");

            return alunos;
        }
    }
}
