using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GroceryPals.Models
{
	public class Order
	{
		[BindNever]
		public int OrderID { get; set; }
		[BindNever]
		public ICollection<CartLine> Lines { get; set; }
		[BindNever]
		public bool Shipped { get; set; }
		[Required(ErrorMessage = "Please enter a name")]
		[RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Please enter valid name like on your card")]

		public string Name { get; set; }
		[Required(ErrorMessage = "Please enter the address")]
		public string Address { get; set; }
		[Required(ErrorMessage = "Please enter a city name")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter valid name of your city")]
		public string City { get; set; }
		[Required(ErrorMessage = "Please enter a state name")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter valid name of your province")]
		public string Province { get; set; }
		[Required(ErrorMessage = "Please enter a postal code")]
		[RegularExpression(@"^\d{6}$", ErrorMessage = "Please enter valid number of 6 symbols")]
		public string PCode { get; set; }
		[Required(ErrorMessage = "Please enter a country name")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter valid country")]
		
		public string Country { get; set; }
		public bool GiftWrap { get; set; }

		public string Customer { get; set; }
	}
}
