using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PhotoStore.ViewModel
{

    public class ApplicationUserViewModel
	{
		[Display(Name = "Login")]
		public virtual string UserName { get; set; }

		[MaxLength(11)]
        public virtual string CPF { get; set; }

        [Required]
        public virtual string Nome { get; set; }

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\([0-9]{2}\))\s([0-9]{4})-([0-9]{4,5})$", ErrorMessage = "Celular Inválido")]
        public virtual string Celular { get; set; }

		[Display(Name = "Fotos deste fotógrafo")]
		public virtual ICollection<FotoViewModel> Fotos { get; set; }

		[Display(Name = "Eventos deste fotógrafo")]
		public virtual ICollection<EventoViewModel> Eventos { get; set; }

    }
}
