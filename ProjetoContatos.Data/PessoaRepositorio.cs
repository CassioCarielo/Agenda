using ProjetoContatos.Dom.Models;
using ProjetoContatos.Dom.Contrato;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjetoContatos.Data
{
    public class PessoaRepositorio : IRepositorioPessoa
    {
        private Contexto contexto;

        private void Inserir(Pessoa pessoa)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append(" INSERT INTO Pessoa (Nome) VALUES ('");
            strQuery.Append(pessoa.Nome);
            strQuery.Append("');");

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery.ToString());
            }

        }

        private void Alterar(Pessoa pessoa)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("UPDATE Pessoa SET");
            strQuery.Append(" Nome = '");
            strQuery.Append(pessoa.Nome);
            strQuery.Append("' WHERE IdPessoa = ");
            strQuery.Append(pessoa.IdPessoa);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery.ToString());
            }

        }

        public void Salvar(Pessoa pessoa)
        {
            if (pessoa.IdPessoa > 0)
            {
                Alterar(pessoa);
            }
            else
            {
                Inserir(pessoa);
            }
        }

        public void Excluir(Pessoa pessoa)
        {
            using (contexto = new Contexto())
            {
                string strQuery = "DELETE FROM Pessoa WHERE IdPessoa = " + pessoa.IdPessoa.ToString();
                contexto.ExecutaComando(strQuery);
            }
        }

        public IEnumerable<Pessoa> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                string strQuery = "SELECT * FROM Pessoa ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Pessoa ListarPorId(string id)
        {
            using (contexto = new Contexto())
            {
                string strQuery = "SELECT * FROM Pessoa WHERE IdPessoa = " + id;
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        public List<Agenda> ListarAgenda()
        {
            using (contexto = new Contexto())
            {
                StringBuilder strQuery = new StringBuilder();
                strQuery.Append(" select p.IdPessoa, ");
                strQuery.Append(" p.Nome NomePessoa, ");
                strQuery.Append(" c.IdContato, ");
                strQuery.Append(" c.Nome NomeContato, ");
                strQuery.Append(" t.IdTipoContato, ");
                strQuery.Append(" t.Tipo, ");
                strQuery.Append(" c.Valor ");
                strQuery.Append(" from Contato c ");
                strQuery.Append(" inner join Pessoa p on p.IdPessoa = c.IdPessoa ");
                strQuery.Append(" inner join TipoContato t on t.IdTipoContato = c.IdTipoContato ");
                var reader = contexto.ExecutaComandoComRetorno(strQuery.ToString());

                List<Agenda> lista = new List<Agenda>();

                while (reader.Read())
                {
                    Agenda agenda = new Agenda();
                    agenda.IdPessoa = Convert.ToInt32(reader["IdPessoa"]);
                    agenda.NomePessoa = reader["NomePessoa"].ToString();
                    agenda.IdPessoa = Convert.ToInt32(reader["IdContato"]);
                    agenda.NomeContato = reader["NomeContato"].ToString();
                    agenda.IdTipoContato = Convert.ToInt32(reader["IdTipoContato"]);
                    agenda.Tipo = reader["Tipo"].ToString();
                    agenda.Valor = reader["Valor"].ToString();

                    lista.Add(agenda);
                }
                reader.Close();

                return lista;
            }
        }

        private List<Pessoa> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            List<Pessoa> lista = new List<Pessoa>();

            while (reader.Read())
            {
                Pessoa pessoa = new Pessoa();
                pessoa.IdPessoa = Convert.ToInt32(reader["IdPessoa"]);
                pessoa.Nome = reader["Nome"].ToString();

                lista.Add(pessoa);
            }
            reader.Close();

            return lista;
        }
    }
}
