using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beyonce.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Beyonce.Controllers
{
    public class LandsController : Controller
    {
        private masterContext _context;

        public LandsController(masterContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Land.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Land land)
        {
            if (ModelState.IsValid)
            {
                _context.Land.Add(land);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(land);
        }

    }
}
