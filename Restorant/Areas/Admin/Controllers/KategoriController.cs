using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KategoriController : Controller
    {
        private readonly IdentityDataContext _context;
        public KategoriController(IdentityDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KategoriEkle()
        {
           // ViewBag.Türler = _context.Türler.ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KategoriEkle(Kategori model, int id, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _context.Kategoriler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("KategoriListele");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult KategoriListele()
        {
            var KategoriListesi = _context.Kategoriler.ToList();

            // Verileri View'e gönder
            return View(KategoriListesi);
        }
        public async Task<IActionResult> KategoriSil(int id)
        {
            var kategori = await _context.Kategoriler.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }

            kategori.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("KategoriListele");
        }

    }
}
