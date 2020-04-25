using log4net;
using Microsoft.AspNetCore.Mvc;
using SomEKart.Models;
using SomEKart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SomEKart.Controllers
{
    public class ShoppingCartController : Controller
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IInventoryRepository inventoryRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _inventoryRepository = inventoryRepository;
        }

        public ViewResult Index()
        {
            var items = _shoppingCartRepository.GetAllCartItems();

            var vm = new ShoppingCartViewModel()
            {
                ShoppingCartItems = items.ToList()
            };

            return View(vm);
        }

        public RedirectToActionResult AddToShoppingCart(int itemId)
        {
            int qty;
            var item = _inventoryRepository.GetItem(itemId, out qty);
            if(qty != 0)
            {
                _shoppingCartRepository.AddItemToCart(item);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int itemId)
        {
            int qty;
            var item = _inventoryRepository.GetItem(itemId, out qty);
            if (item != null)
            {
                _shoppingCartRepository.RemoveItemFromCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
