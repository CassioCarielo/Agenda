namespace ProjetoContatos.Dom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contato")]
    public partial class Contato
    {
        public int IdContato { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public int IdPessoa { get; set; }

        public int IdTipoContato { get; set; }

        [Required]
        [StringLength(150)]
        public string Valor { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual TipoContato TipoContato { get; set; }
    }
}
