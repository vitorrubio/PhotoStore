using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.ViewModel.Home
{
	public class HomeIndexViewModel
	{

		const int COLUNAS = 4;


		[Display(Name = "Nome do Evento")]
		public virtual string Evento { get; set; }

		[Display(Name = "Nome")]
		public virtual string Nome { get; set; }

		[Display(Name = "Número")]
		public virtual string Numero { get; set; }


		public virtual IList<PhotoStore.ViewModel.FotoViewModel> Fotos { get; set; }
		public virtual IList<PhotoStore.ViewModel.EventoViewModel> EventosMaisRecentes { get; set; }
		public virtual IList<PhotoStore.ViewModel.EventoViewModel> EventosMaisAntigos { get; set; }
		public virtual IList<PhotoStore.ViewModel.EventoViewModel> Eventos { get; set; }


		public virtual List<List<EventoViewModel>> ObterMatrizEventos(IList<EventoViewModel> lista)
		{
			List<List<EventoViewModel>> result = new List<List<EventoViewModel>>();

			int contador = 0;
			List<EventoViewModel> listaAtual = new List<EventoViewModel>();
			foreach(var item in lista)
			{
				if(contador % COLUNAS == 0)
				{
					listaAtual = new List<EventoViewModel>();
					result.Add(listaAtual);
				}

				listaAtual.Add(item);

				contador++;
			}

			return result;
		}


		public virtual List<List<FotoViewModel>> ObterMatrizFotos(IList<FotoViewModel> lista)
		{
			List<List<FotoViewModel>> result = new List<List<FotoViewModel>>();

			int contador = 0;
			List<FotoViewModel> listaAtual = new List<FotoViewModel>();
			foreach (var item in lista)
			{
				if (contador % COLUNAS == 0)
				{
					listaAtual = new List<FotoViewModel>();
					result.Add(listaAtual);
				}

				listaAtual.Add(item);

				contador++;
			}

			return result;
		}
	}
}
