using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;
using System;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("musteri_area")]
    public class Rezervasyon_MusteriController : Controller
    {
        private readonly IdentityDataContext _context;
        public Rezervasyon_MusteriController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Masalar = _context.Masalar.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(MasaRezervasyon model)
        {
            if (ModelState.IsValid)
            {
                _context.MasaRezervasyonlar.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
