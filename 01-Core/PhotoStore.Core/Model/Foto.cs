using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoStore.Core.Model
{
    public class Foto : Entidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Display(Name = "Evento")]
        public virtual Evento Evento { get; set; }

        [Display(Name = "Nome do Arquivo")]
        public virtual string NomeArquivo { get; set; }

        [Display(Name = "MD5")]
        public virtual string MD5 { get; set; }

        [Display(Name = "Nome na Foto")]
        public virtual string Nome { get; set; }

        [Display(Name = "Número na Foto")]
        public virtual string Numero { get; set; }

        [Display(Name = "Fotógrafo")]
        public virtual ApplicationUser Fotografo { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

		public virtual bool Vitrine { get; set; }

    }


}