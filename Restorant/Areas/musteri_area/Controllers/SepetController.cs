using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;
using System;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("musteri_area")]
    public class SepetController : Controller
    {
        private readonly IdentityDataContext _context;
        public SepetController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Urunler = _context.Urunler.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(int id, int miktar)
        {
            var urun = _context.Urunler.FirstOrDefault(x => x.Id == id);
            if (urun != null)
            {
                Sepet sepet = new Sepet();
                sepet.UrunId = urun.Id;
                sepet.MenuId = 0;
                sepet.Fiyat = urun.Fiyat;
                sepet.Miktar = miktar;

                _context.Add(sepet);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MenuEkle(int id, int miktar)
        {
            var menu = _context.Menuler.FirstOrDefault(x => x.Id == id);
            if (menu != null)
            {
                Sepet sepet = new Sepet();
                sepet.UrunId = 0;
                sepet.MenuId = menu.Id;
                sepet.Fiyat = menu.Fiyat;
                sepet.Miktar = miktar;

                _context.Add(sepet);
            }

            return RedirectToAction("Index");
        }
    }
}
