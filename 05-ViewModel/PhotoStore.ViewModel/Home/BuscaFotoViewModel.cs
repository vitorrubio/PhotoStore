using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.ViewModel.Home
{
	public class BuscaFotoViewModel
	{
		[Display(Name = "Nome do Evento")]
		public virtual int EventoId { get; set; }

		[Display(Name = "Nome")]
		public virtual string NomeOuNumero { get; set; }
	}
}
