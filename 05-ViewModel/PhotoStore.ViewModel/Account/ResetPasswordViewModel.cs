using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhotoStore.ViewModel.Account
{
	public class ResetPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "O/A {0} deve ter no mínimo {2} caracteres.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Senha")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirmar senha")]
		[Compare("Password", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
		public string ConfirmPassword { get; set; }

		public string Code { get; set; }
	}
}
