using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using WebApi.Dominio.Interfaces;
using WebApi.Dominio.Models;
using WebApi.Infraestrutura.Data;

namespace WebApi.Infraestrutura.Repositorios
{
    public class EscolaRepositorio : IEscolaRepositorio
    {
        DataContext _dataContext;
        public EscolaRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Criar(Escola escola)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _dataContext.Database.EnsureCreated();
                _dataContext.Escolas.Add(escola);
                _dataContext.SaveChanges();
                scope.Complete();
            }
        }

        public void Atualizar(Escola escola)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _dataContext.Database.EnsureCreated();
                _dataContext.Update<Escola>(escola);
                _dataContext.SaveChanges();

                scope.Complete();
            }
        }

        public Escola ObterPorId(string codigoINEP)
        {
            _dataContext.Database.EnsureCreated();
            Escola escola = new Escola();

            escola = _dataContext.Escolas.Where(c => c.CodigoINEP == codigoINEP).AsNoTracking().FirstOrDefault();
            if (escola == null || escola.CodigoINEP == null)
                throw new Exception("Nenhuma escola Encontrado");

            return escola;
        }

        public List<Escola> ObterTodos()
        {
            _dataContext.Database.EnsureCreated();
            List<Escola> escolas = new List<Escola>();

            escolas = _dataContext.Escolas.AsNoTracking().ToList();
            if (escolas == null || escolas.Count == 0)
                throw new Exception("Nenhuma escola Encontrado");

            return escolas;
        }
    }
}
