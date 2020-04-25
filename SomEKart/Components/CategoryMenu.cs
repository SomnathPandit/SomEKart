using Microsoft.AspNetCore.Mvc;
using SomEKart.Models;
using SomEKart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Components
{
    public class CategoryMenu : ViewComponent
    {
        IInventoryRepository _inventory;
        public CategoryMenu(IInventoryRepository inventory)
        {
            _inventory = inventory;
        }

        public IViewComponentResult Invoke()
        {
            var categories = Enum.GetNames(typeof(Category)).ToList();
            return View(new CategoryMenuViewModel() { Categories = categories });
        }
    }
}
