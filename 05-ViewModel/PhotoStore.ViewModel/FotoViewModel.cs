using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoStore.ViewModel
{
    public class FotoViewModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Display(Name = "Evento")]
        public virtual EventoViewModel Evento { get; set; }

        [Display(Name = "Nome do Arquivo")]
        public virtual string NomeArquivo { get; set; }

        [Display(Name = "MD5")]
        public virtual string MD5 { get; set; }

        [Display(Name = "Nome na Foto")]
        public virtual string Nome { get; set; }

        [Display(Name = "Número na Foto")]
        public virtual string Numero { get; set; }

        [Display(Name = "Fotógrafo")]
        public virtual ApplicationUserViewModel Fotografo { get; set; }

		public virtual bool Vitrine { get; set; }


		public virtual ArquivoFotoViewModel ArquivoFoto { get; set; }

    }


}