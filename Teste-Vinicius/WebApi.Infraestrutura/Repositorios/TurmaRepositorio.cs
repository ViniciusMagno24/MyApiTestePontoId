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
    public class TurmaRepositorio : ITurmaRepositorio
    {
        DataContext _dataContext;
        public TurmaRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Criar(Turma turma)
        {
            _dataContext.Database.EnsureCreated();
            _dataContext.Turmas.Add(turma);
            _dataContext.SaveChanges();
        }

        public void Atualizar(Turma turma)
        {
            _dataContext.Database.EnsureCreated();
            _dataContext.Update<Turma>(turma);
            _dataContext.SaveChanges();
        }

        public List<Turma> ObterPorCodigoEscolar(string codigoINEP)
        {
            _dataContext.Database.EnsureCreated();
            List<Turma> turmas = new List<Turma>();

            turmas = _dataContext.Turmas.Where(c => c.CodigoEscolar == codigoINEP).AsNoTracking().ToList();
            if (turmas == null || turmas.Count == 0)
                throw new Exception("Nenhuma turma Encontrado");

            return turmas;
        }

        public Turma ObterPorId(int id)
        {
            _dataContext.Database.EnsureCreated();
            Turma turma = new Turma();

            turma = _dataContext.Turmas.Where(c => c.Id == id).AsNoTracking().FirstOrDefault();
            if (turma == null || turma.Id == 0)
                throw new Exception("Nenhuma turma Encontrado");

            return turma;
        }

        public List<Turma> ObterTodos()
        {
            _dataContext.Database.EnsureCreated();
            List<Turma> turmas = new List<Turma>();

            turmas = _dataContext.Turmas.AsNoTracking().ToList();
            if (turmas == null || turmas.Count == 0)
                throw new Exception("Nenhuma turma cadastrada");

            return turmas;
        }
    }
}
