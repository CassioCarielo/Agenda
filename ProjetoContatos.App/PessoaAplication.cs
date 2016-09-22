using ProjetoContatos.Srv;
using ProjetoContatos.Dom.Models;
using System.Collections.Generic;

namespace ProjetoContatos.App
{
    public class PessoaAplication
    {
        private readonly PessoaService pessoaService = new PessoaService();
        public void Salvar(Pessoa pessoa)
        {
            pessoaService.Salvar(pessoa);
        }
        public void Excluir(Pessoa pessoa)
        {
            pessoaService.Excluir(pessoa);
        }

        public IEnumerable<Pessoa> ListarTodos()
        {
            return pessoaService.ListarTodos();
        }

        public Pessoa ListarPorId(string id)
        {
            return pessoaService.ListarPorId(id);
        }
        public List<Agenda> ListarAgenda()
        {
            return pessoaService.ListarAgenda();
        }
    }
}
