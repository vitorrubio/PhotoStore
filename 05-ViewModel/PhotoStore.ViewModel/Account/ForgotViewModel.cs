using System.ComponentModel.DataAnnotations;


namespace PhotoStore.ViewModel.Account
{
	public class ForgotViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}
