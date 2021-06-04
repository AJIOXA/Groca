using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GroceryPals.Models;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace GroceryPals.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{

		private IProductRepository repository;
		public AdminController(IProductRepository repo)
		{
			repository = repo;
		}
		public ViewResult Index() => View(repository.Products);

		public ViewResult Edit(int productId) =>
			View(repository.Products
			.FirstOrDefault(p => p.ProductID == productId));
		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				repository.SaveProduct(product);
				TempData["message"] = $"{product.Name} has been saved";
				return RedirectToAction("Index");
			}
			else
			{
				// there is something wrong with the data values
				return View(product);
			}
		}

		public ViewResult Create() => View("Edit", new Product());

		[HttpPost]
		public IActionResult Delete(int productId)
		{
			Product deletedProduct = repository.DeleteProduct(productId);
			if (deletedProduct != null)
			{
				TempData["message"] = $"{deletedProduct.Name} was deleted";
			}
			return RedirectToAction("Index");
		}

		public FileResult SaveUsers()
		{
			var options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin),
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true,
				IgnoreNullValues = true
			};

			var json = JsonSerializer.Serialize(repository.Products, options);
			System.IO.File.WriteAllText($"{Environment.CurrentDirectory}\\file.json", json);
			byte[] fileBytes = System.IO.File.ReadAllBytes($"{Environment.CurrentDirectory}\\file.json");
			string fileName = "users.json";
			return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
		}
	}
}