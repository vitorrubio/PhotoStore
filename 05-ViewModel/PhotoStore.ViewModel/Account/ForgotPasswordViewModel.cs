using System.ComponentModel.DataAnnotations;


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
