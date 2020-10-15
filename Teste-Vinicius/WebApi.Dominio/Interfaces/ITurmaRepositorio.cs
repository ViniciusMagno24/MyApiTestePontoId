using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Models;

namespace WebApi.Dominio.Interfaces
{
    public interface ITurmaRepositorio
    {
        void Criar(Turma turma);
        void Atualizar(Turma turma);
        Turma ObterPorId(int id);
        List<Turma> ObterPorCodigoEscolar(string codigoINEP);
        List<Turma> ObterTodos();
    }
}
