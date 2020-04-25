using Microsoft.AspNetCore.Mvc;
using SomEKart.Models;
using SomEKart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        IShoppingCartRepository _repository;

        public ShoppingCartSummary(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var items = _repository.GetAllCartItems();

            var vm = new ShoppingCartViewModel() { 
                ShoppingCartItems = items                
            };

            return View(vm);
        }
    }
}
