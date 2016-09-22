using ProjetoContatos.Dom.Models;
using System.Collections.Generic;

namespace ProjetoContatos.Dom.Contrato
{
    public interface IRepositorioPessoa : IRepositorioBase<Pessoa>
    {
        List<Agenda> ListarAgenda();
    }
}
