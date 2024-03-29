﻿using GroceryPals.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GroceryPals.Controllers
{
    public class OrderController : Controller
    {
		private IOrderRepository repository;
		private Cart cart;
		public OrderController(IOrderRepository repoService, Cart cartService)
		{
			repository = repoService;
			cart = cartService;
		}
		[Authorize]
		public ViewResult List() =>
			View(repository.Orders.Where(o => !o.Shipped));

		[HttpPost]
		[Authorize]
		public IActionResult MarkShipped(int orderID)
		{
			Order order = repository.Orders
			.FirstOrDefault(o => o.OrderID == orderID);
			if (order != null)
			{
				order.Shipped = true;
				repository.SaveOrder(order);
			}
			return RedirectToAction(nameof(List));
		}

		public ViewResult Checkout() => View(new Order());
		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			if (cart.Lines.Count() == 0)
			{
				ModelState.AddModelError("", "Sorry, your cart is empty!");
			}
			if (ModelState.IsValid)
			{
				order.Lines = cart.Lines.ToArray();
				repository.SaveOrder(order);
				return RedirectToAction(nameof(payment));
			}
            else
			{
				return View(order);
			}
		}
		public ViewResult payment() => View(new PaymentInf());
		
		[HttpPost]
		public IActionResult Payment(PaymentInf payment)
		{
			
			if (ModelState.IsValid)
			{
				cart.Clear();
				return View(nameof(completed));
			}
			//ModelState.AddModelError("", "Invalid payment information, try again");
			return View(nameof(payment));
		}
        public ViewResult completed()
        {
            cart.Clear();
            return View();
        }

        public IActionResult History() =>
			View(repository.Orders);
	}
}