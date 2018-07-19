using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.ViewModel.Home
{
	public class BuscaEventoViewModel
	{
		[Display(Name = "Nome do Evento")]
		public virtual string Evento { get; set; }

		[Display(Name = "Nome")]
		public virtual string NomeOuNumero { get; set; }
	}
}
