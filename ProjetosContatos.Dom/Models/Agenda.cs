using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoContatos.Dom.Models
{
    public class Agenda
    {
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }
        public int IdContato { get; set; }
        public string NomeContato { get; set; }
        public int IdTipoContato { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
    }
}
