﻿using System.ComponentModel.DataAnnotations;

namespace PhotoStore.ViewModel.Account
{
	public class RegisterViewModel
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
		[Display(Name = "Confirmar Senha")]
		[Compare("Password", ErrorMessage = "A senha e a senha de confirmação não correspondem.")]
		public string ConfirmPassword { get; set; }
	}
}
