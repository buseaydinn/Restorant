using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;
namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunController : Controller
    {
        private readonly IdentityDataContext _context;

        public UrunController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UrunEkle()
        {
            ViewBag.Kategori = _context.Kategoriler.ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urun model, int id)
        {
          ViewBag.Kategori = _context.Kategoriler.ToList();

            if (ModelState.IsValid)
            {
                _context.Urunler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("UrunListele");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult UrunListele()
        {
            List<Urun> urunListesi = _context.Urunler.Include(x => x.Kategori).ToList();

            // Verileri View'e gönder
            return View(urunListesi);
        }

        public async Task<IActionResult> UrunSil(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }

            urun.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("UrunListele");
        }




    }
}
