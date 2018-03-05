using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.ViewModel.Manage
{

	public class VerifyPhoneNumberViewModel
	{
		[Required]
		[Display(Name = "Código")]
		public string Code { get; set; }

		[Required]
		[Phone]
		[Display(Name = "Número de telefone")]
		public string PhoneNumber { get; set; }
	}
}
