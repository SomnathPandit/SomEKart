using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomEKart.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SomEKart.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _invetoryRepository;

        public InventoryController(IInventoryRepository invetoryRepository)
        {
            _invetoryRepository = invetoryRepository;
        }
        
        public ViewResult List()
        {
            ViewBag.Title = "Som's E-Kart";
            return View(_invetoryRepository.GetAllItems());
        }

        public IActionResult Details(int id)
        {
            int qty;
            var item = _invetoryRepository.GetItem(id, out qty);
            if (qty == 0)
                return NotFound();
            return View(item);
        }
    }
}
