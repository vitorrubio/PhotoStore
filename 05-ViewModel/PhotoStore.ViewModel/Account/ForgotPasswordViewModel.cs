using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.ViewModel.Account
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "E-mail")]
		public string Email { get; set; }
	}
}
