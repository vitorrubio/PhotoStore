using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.ViewModel.Admin.FotoAdmin
{
	public class FotoAdminIndexViewModel
	{
		[Display(Name = "Nome do Evento")]
		public virtual string Evento { get; set; }

		[Display(Name = "Nome")]
		public virtual string Nome { get; set; }

		[Display(Name = "Número")]
		public virtual string Numero { get; set; }

		public virtual IEnumerable<PhotoStore.ViewModel.FotoViewModel> Fotos { get; set; }


	}
}
