using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhotoStore.Core.Model
{
    public class ArquivoCapa : Entidade
    {
        [Key]
        [ForeignKey("Evento")]
        public override int Id { get; set; }

        [Display(Name = "Evento")]
        public virtual Evento Evento { get; set; }

		[Display(Name = "Nome do Arquivo")]
		public virtual string NomeDoArquivo { get; set; }

		[Display(Name = "Conteúdo do Arquivo")]
		public virtual byte[] Bytes { get; set; }


    }
}