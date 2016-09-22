namespace ProjetoContatos.Dom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoContato")]
    public partial class TipoContato
    {
        public int IdTipoContato { get; set; }

        [Required]
        [StringLength(10)]
        public string Tipo { get; set; }
    }
}
