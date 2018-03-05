using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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


    }
}