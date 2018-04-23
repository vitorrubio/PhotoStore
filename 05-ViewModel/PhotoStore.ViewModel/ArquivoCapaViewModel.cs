using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace PhotoStore.ViewModel
{
    public class ArquivoCapaViewModel
	{

        public virtual int Id { get; set; }

        [Display(Name = "Evento")]
        public virtual EventoViewModel Evento { get; set; }

		[Display(Name = "Nome do Arquivo")]
		public virtual string NomeDoArquivo { get; set; }

		[Display(Name = "Conteúdo do Arquivo")]
		public virtual byte[] Bytes { get; set; }

		public virtual string Base64SourceString
		{
			get
			{
				var extension = Path.GetExtension(NomeDoArquivo);
				var base64 = Convert.ToBase64String(Bytes);
				return String.Format("data:image/{0};base64,{1}", base64, extension);
			}
		}
    }
}