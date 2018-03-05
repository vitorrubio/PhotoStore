using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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