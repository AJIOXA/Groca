using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GroceryPals.Models
{
	public class PaymentInf
	{
		[Required(ErrorMessage = "Please enter a name on card")]
		[RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Please enter valid name on card")]
		public string NameOnCard { get; set; }
		[Required(ErrorMessage = "Please enter the Card Number")]
		[RegularExpression(@"^\d{16}$", ErrorMessage = "Please enter valid number in format 1111 2222 3333 4444")]
		public string CardNumber { get; set; }
		[Required(ErrorMessage = "Please enter an expiry date")]
		//[RegularExpression(@"^(?:01|02|03|04|05|06|07|08|09|10|11|12).(?:21|22|23|24|25|26|27|28)$", ErrorMessage = "Please enter valid expiry date in format xx.yy")]
		public int ExpiryDate1 { get; set; }
		public int ExpiryDate2 { get; set; }
		[Required(ErrorMessage = "Please enter a cvc code")]
		[RegularExpression(@"^\d{3}$", ErrorMessage = "Please enter valid cvc")]
		public string CVCNumber { get; set; }
		
		public bool debit { get; set; }
		public bool credit { get; set; }
	}
}
