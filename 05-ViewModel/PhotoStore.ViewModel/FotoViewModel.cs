using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhotoStore.ViewModel
{
    public class FotoViewModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Display(Name = "Evento")]
        public virtual EventoViewModel Evento { get; set; }

		[Display(Name = "Evento")]
		public virtual int IdEvento { get; set; }

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

		[Display(Name = "Mostrar na Vitrine")]
		public virtual bool Vitrine { get; set; }

		[Display(Name = "Capa de Evento")]
		public virtual bool CapaDeEvento { get; set; }

		[Display(Name = "Arquivo da Foto")]
		public virtual ArquivoFotoViewModel ArquivoFoto { get; set; }

    }


}