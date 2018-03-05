﻿using System.ComponentModel.DataAnnotations;


namespace PhotoStore.ViewModel.Account
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Email")]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Senha")]
		public string Password { get; set; }

		[Display(Name = "Lembrar-me?")]
		public bool RememberMe { get; set; }
	}
}
