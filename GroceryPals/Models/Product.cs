using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryPals.Models
{
	public class Product
	{
        [Required(ErrorMessage = "Please enter product Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter valid name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please enter Product ID")]
        public int ProductID { get; set; }
		
        public string Description { get; set; }


        [Required(ErrorMessage = "Please enter product Price.")]
        //[RegularExpression(@"^\d+(?:\.\d{1,2})?$", ErrorMessage = "Please enter valid Price")]
        public double Price { get; set; }


        public string Category { get; set; }
        [RegularExpression(@"^20(?:09|10|11|12|13|14|15|16|17|18|19|20|21)$", ErrorMessage = "Please enter valid year")]
        public string Year { get; set; }

		[Required(ErrorMessage = "Please specify the shipping status")]
		public String FreeShip { get; set; }

		
		public string Comment { get; set; }

		public string CusName { get; set; }
	}
}
