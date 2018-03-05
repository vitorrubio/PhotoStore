using System.ComponentModel.DataAnnotations;


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
