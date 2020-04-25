using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using SomEKart.Models;
using SomEKart.ViewModels;

namespace SomEKart.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository _orderRepository;
        IShoppingCartRepository _shoppingCartRepository;
        IInventoryRepository _inventoryRepository;

        public OrderController(IInventoryRepository inventoryRepository, IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _inventoryRepository = inventoryRepository;
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Billing billing)
        {
            var items = _shoppingCartRepository.GetAllCartItems();
            if(items.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty! Please add some items in cart.");
            }

            if(ModelState.IsValid)
            {
                var order = new Order();
                _orderRepository.CreateOrder(order);
                billing.OrderId = order.Id;
                var ordervm = new OrderViewModel() { Order = order, BillingDetails = billing };
                TempData["ordervm"] = JsonConvert.SerializeObject(ordervm);
                return RedirectToAction("Payment", "Billing", new { param= "ordervm" });
            }

            return View();
        }

        public IActionResult OrderSummary(int orderid)
        {
            var order = _orderRepository.GetOrder(orderid);
            return View(order);
        }
    }
}