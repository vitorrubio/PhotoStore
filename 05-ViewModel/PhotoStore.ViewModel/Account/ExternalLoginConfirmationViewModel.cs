using System.ComponentModel.DataAnnotations;


namespace PhotoStore.ViewModel.Account
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}
