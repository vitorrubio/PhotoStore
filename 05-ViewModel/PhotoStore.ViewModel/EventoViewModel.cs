using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace PhotoStore.ViewModel
{
    public class EventoViewModel
	{
		public EventoViewModel()
		{
			this.Inicio = DateTime.Today;
		}


        public virtual int Id { get; set; }

        [Display(Name = "Fotos deste evento")]
        public virtual ICollection<FotoViewModel> Fotos { get; set; }

		[Display(Name = "Mostrar na Vitrine")]
		public virtual bool Vitrine { get; set; }

		[Display(Name = "Fotógrafos deste evento")]
		public virtual ICollection<ApplicationUserViewModel> Fotografos { get; set; }

		[Required]
        [MaxLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres")]
        [Display(Name = "Nome")]
        public virtual string Nome { get; set; }

        [MaxLength(2000, ErrorMessage = "A descrição deve ter no máximo 2000 caracteres")]
        [Display(Name = "Descrição")]
        public virtual string Descricao { get; set; }

        [Display(Name = "Início")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public virtual  DateTime Inicio { get; set; }

        [Display(Name = "Fim")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public virtual DateTime? Fim { get; set; }


    }
}