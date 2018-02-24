using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoStore.Core.Model
{
    public class Produto : Entidade
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public virtual Foto Foto { get; set; }

        public virtual TipoProduto Tipo { get; set; }


    }
}