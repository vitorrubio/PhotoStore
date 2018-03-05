﻿using System.ComponentModel.DataAnnotations;


namespace PhotoStore.ViewModel.Account
{
	public class VerifyCodeViewModel
	{
		[Required]
		public string Provider { get; set; }

		[Required]
		[Display(Name = "Código")]
		public string Code { get; set; }
		public string ReturnUrl { get; set; }

		[Display(Name = "Lembrar deste navegador?")]
		public bool RememberBrowser { get; set; }

		public bool RememberMe { get; set; }
	}
}
