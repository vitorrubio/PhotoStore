using PhotoStore.CrossCutting;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PhotoStore.ViewModel
{
    public class UploadFotoViewModel
    {
		public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }


		[Display(Name = "Evento")]
		public virtual EventoViewModel Evento { get; set; }

		[Display(Name = "Evento")]
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
		public virtual ApplicationUserViewModel Fotografo { get; set; }

		[Display(Name = "Mostrar na Vitrine")]
		public virtual bool Vitrine { get; set; }

		[Display(Name = "Capa de Evento")]
		public virtual bool CapaDeEvento { get; set; }

		[Display(Name = "Arquivo da Foto")]
		public virtual ArquivoFotoViewModel ArquivoFoto { get; set; }


		[Required(ErrorMessage = "Por favor selecione uma foto.")]
        [FileTypes("jpg,jpeg,png,bmp,gif")]
        [DataType(DataType.Upload)]
        [Display(Name = "Foto")]
        public virtual HttpPostedFileBase ArquivoAnexo { get; set; }

    }
}