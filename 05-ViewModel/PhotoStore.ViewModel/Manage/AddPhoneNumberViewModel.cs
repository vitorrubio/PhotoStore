﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
