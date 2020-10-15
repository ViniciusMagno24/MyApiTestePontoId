using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Models;

namespace WebApi.Dominio.Interfaces
{
    public interface IAlunoRepositorio
    {
        void Criar(Aluno aluno);
        void Atualizar(Aluno aluno);
        Aluno ObterPorId(string cpf);
        List<Aluno> ObterPorCodigoINEP(string codigo);
        List<Aluno> ObterPorTurmaId(int turmaId);
        List<Aluno> ObterTodos();
    }
}
