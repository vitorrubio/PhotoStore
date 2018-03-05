using System.ComponentModel.DataAnnotations;


namespace PhotoStore.ViewModel.Manage
{
	public class AddPhoneNumberViewModel
	{
		[Required]
		[Phone]
		[Display(Name = "Número de telefone")]
		public string Number { get; set; }
	}
}
