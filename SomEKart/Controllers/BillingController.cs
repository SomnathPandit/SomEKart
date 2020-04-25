using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SomEKart.Models;
using SomEKart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Controllers
{
    public class BillingController : Controller
    {
        AppDbContext _context;
        public BillingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Payment(string param)
        {
            var obj = JsonConvert.DeserializeObject<OrderViewModel>((string)TempData[param]);

            return View(obj);
        }
    }
}
