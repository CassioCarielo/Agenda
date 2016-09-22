using System.Collections.Generic;

namespace ProjetoContatos.Dom.Contrato
{
    public interface IRepositorioBase<T> where T : class // Pode ser qualquer coisa, sendo uma classe!
    {
        void Salvar(T entidade);

        void Excluir(T entidade);

        IEnumerable<T> ListarTodos();

        T ListarPorId(string id);
    }
}
