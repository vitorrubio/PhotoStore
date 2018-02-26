using PhotoStore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoStore.ViewModel
{
    public class UploadFotoViewModel
    {

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }





        public virtual int IdEvento { get; set; }

        public virtual string LoginFotografo { get; set; }

        public virtual string NomeArquivo { get; set; }

        public virtual string MD5 { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Numero { get; set; }


        [Required(ErrorMessage = "Por favor selecione uma foto.")]
        [FileTypes("jpg,jpeg,png,bmp,gif")]
        [DataType(DataType.Upload)]
        [Display(Name = "Foto")]
        public virtual HttpPostedFileBase ArquivoAnexo { get; set; }

    }
}