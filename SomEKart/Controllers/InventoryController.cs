using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Mvc;
using SomEKart.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SomEKart.Controllers
{
    public class InventoryController : Controller
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IInventoryRepository _invetoryRepository;

        public InventoryController(IInventoryRepository invetoryRepository)
        {
            _invetoryRepository = invetoryRepository;
        }
        
        //public ViewResult List()
        //{
        //    _log.Info("Loading inventory...");
        //    ViewBag.Title = "Som's E-Kart";
        //    return View(_invetoryRepository.GetAllItems());
        //}

        public ViewResult List(string category)
        {
            _log.Info("Loading category wise inventory...");
            ViewBag.Title = "Som's E-Kart";

            IEnumerable<Item> items = null;
            Category cat;
            var parsed = Enum.TryParse<Category>(category, out cat);

            if (string.IsNullOrEmpty(category) || !parsed)
            {
                items = _invetoryRepository.GetAllItems();
            }
            else
            {
                items = _invetoryRepository.GetAllItems().Where(a => a.Category == cat);
            }

            return View(items);
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
