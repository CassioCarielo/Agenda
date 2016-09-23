using ProjetoContatos.Data;
using ProjetoContatos.Dom.Models;
using System.Collections.Generic;

namespace ProjetoContatos.Srv
{
    public class PessoaService
    {
        private readonly PessoaRepositorio pessoaRepositorio = new PessoaRepositorio();

        public void Salvar(Pessoa pessoa)
        {
            pessoaRepositorio.Salvar(pessoa);
        }
        public void Excluir(Pessoa pessoa)
        {
            pessoaRepositorio.Excluir(pessoa);
        }

        public IEnumerable<Pessoa> ListarTodos()
        {
            return pessoaRepositorio.ListarTodos();
        }

        public Pessoa ListarPorId(string id)
        {
            return pessoaRepositorio.ListarPorId(id);
        }

        public List<Agenda> ListarAgenda()
        {
            return pessoaRepositorio.ListarAgenda();
        }
    }
}
