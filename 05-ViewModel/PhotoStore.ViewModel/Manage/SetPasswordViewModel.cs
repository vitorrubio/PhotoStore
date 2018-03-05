﻿using System.ComponentModel.DataAnnotations;


namespace PhotoStore.ViewModel.Manage
{
	public class SetPasswordViewModel
	{
		[Required]
		[StringLength(100, ErrorMessage = "{0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Nova senha")]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirmar nova senha")]
		[Compare("NewPassword", ErrorMessage = "A nova senha e a senha de confirmação não correspondem.")]
		public string ConfirmPassword { get; set; }
	}
}
