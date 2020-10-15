using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Models;

namespace WebApi.Dominio.Interfaces
{
    public interface IEscolaRepositorio
    {
        void Criar(Escola escola);
        void Atualizar(Escola escola);
        Escola ObterPorId(string codigoINEP);
        List<Escola> ObterTodos();
    }
}
