using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhotoStore.Core.Model
{
    public class ArquivoFoto : Entidade
    {
        [Key]
        [ForeignKey("Foto")]
        public override int Id { get; set; }

        [Display(Name = "Foto")]
        public virtual Foto Foto { get; set; }

        public virtual byte[] Bytes { get; set; }


    }
}