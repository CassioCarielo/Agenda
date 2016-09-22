namespace ProjetoContatos.Dom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pessoa")]
    public partial class Pessoa
    {
        public int IdPessoa { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public virtual ICollection<Contato> Contato { get; set; }
    }
}
