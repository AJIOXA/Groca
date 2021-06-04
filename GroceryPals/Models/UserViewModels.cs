using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryPals.Models
{
	public class CreateModel
	{
		[Required (ErrorMessage ="Please Enter Account Name")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please Enter Account Password")]
		public string Role { get; set; }
		[Required(ErrorMessage = "Please Specify Account Type")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Please Enter Email")]
		[RegularExpression(@"^[\w\d]+(?:\.[\w\d]+){0,}@\w+\.\w+$", ErrorMessage = "Please enter valid email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Please Enter Number")]
		[RegularExpression(@"^((80|375)[\- ]?)?(\(?\d{2}\)?[\- ]?)?[\d\- ]{7}$", ErrorMessage = "Please enter valid number without +")]
		public string PhoneNumber { get; set; }
	}
}
