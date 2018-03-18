using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace PhotoStore.ViewModel
{
    public class ArquivoFotoViewModel
	{
        [Key]
        [ForeignKey("Foto")]
        public virtual int Id { get; set; }

        [Display(Name = "Foto")]
        public virtual FotoViewModel Foto { get; set; }

        public virtual byte[] Bytes { get; set; }

		public virtual string Base64SourceString
		{
			get
			{
				var extension = Path.GetExtension(Foto.NomeArquivo);
				var base64 = Convert.ToBase64String(Bytes);
				return String.Format("data:image/{0};base64,{1}", base64, extension);
			}
		}
    }
}