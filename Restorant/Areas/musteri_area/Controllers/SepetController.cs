using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;
using System;
using System.Linq;

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
            ViewBag.Sepetler = _context.Sepetler.ToList();
            ViewBag.Urunler = _context.Urunler.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(int id, int miktar)
        {
            var urun = _context.Urunler.FirstOrDefault(x => x.Id == id);
            if (urun != null)
            {
                Sepet sepet = new Sepet
                {
                    UrunId = urun.Id,
                    MenuId = 0,
                    Fiyat = urun.Fiyat,
                    Miktar = miktar
                };

                _context.Add(sepet);
                _context.SaveChanges(); // Değişiklikleri kaydediyoruz
                // Kayıt kontrolü
                if (_context.Sepetler.Any(x => x.UrunId == urun.Id && x.Miktar == miktar))
                {
                    Console.WriteLine("Ürün sepete başarıyla eklendi.");
                }
                else
                {
                    Console.WriteLine("Ürün sepete eklenemedi.");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MenuEkle(int id, int miktar)
        {
            var menu = _context.Menuler.FirstOrDefault(x => x.Id == id);
            if (menu != null)
            {
                Sepet sepet = new Sepet
                {
                    UrunId = 0,
                    MenuId = menu.Id,
                    Fiyat = menu.Fiyat,
                    Miktar = miktar
                };

                _context.Add(sepet);
                _context.SaveChanges(); // Değişiklikleri kaydediyoruz
                // Kayıt kontrolü
                if (_context.Sepetler.Any(x => x.MenuId == menu.Id && x.Miktar == miktar))
                {
                    Console.WriteLine("Menü sepete başarıyla eklendi.");
                }
                else
                {
                    Console.WriteLine("Menü sepete eklenemedi.");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
