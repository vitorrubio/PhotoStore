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
		public virtual int IdEvento { get; set; }

		[Display(Name = "Nome do Arquivo")]
		public virtual string NomeArquivo { get; set; }

		[Display(Name = "MD5")]
		public virtual string MD5 { get; set; }

		[Display(Name = "Nome na Foto")]
		public virtual string Nome { get; set; }

		[Display(Name = "Número na Foto")]
		public virtual string Numero { get; set; }


        [Required(ErrorMessage = "Por favor selecione uma foto.")]
        [FileTypes("jpg,jpeg,png,bmp,gif")]
        [DataType(DataType.Upload)]
        [Display(Name = "Foto")]
        public virtual HttpPostedFileBase ArquivoAnexo { get; set; }

    }
}