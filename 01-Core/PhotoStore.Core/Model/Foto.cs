using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhotoStore.Core.Model
{
    public class Foto : Entidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Display(Name = "Evento")]		
		public virtual Evento Evento { get; set; }

		[ForeignKey("Evento")]
		public virtual int EventoId { get; set; }

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

		[Display(Name = "Mostrar na Vitrine")]
		public virtual bool Vitrine { get; set; }

		[Display(Name = "Capa de Evento")]
		public virtual bool CapaDeEvento { get; set; }

		[Display(Name = "Arquivo da Foto")]
		public virtual ArquivoFoto ArquivoFoto { get; set; }

		[Display(Name = "Retrato ou Paisagem")]
		public virtual bool Retrato { get; set; }

	}


}