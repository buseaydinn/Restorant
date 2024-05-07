using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StokController : Controller
    {

        private readonly IdentityDataContext _context;

        public StokController(IdentityDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StokEkle()
        {
        
            ViewBag.Tedarikci = _context.Tedarikciler.ToList();
            ViewBag.Malzeme = _context.Malzemeler.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult StokEkle(StokGirdi model, int id, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                // Veritabanından ilgili stoğu bul
                var stok = _context.Stoklar.FirstOrDefault(x => x.Id == model.MalzemeId);

                // Stoğu bulamazsanız hata döndür
                if (stok == null)
                {
                    ModelState.AddModelError(string.Empty, "Belirtilen stok bulunamadı.");
                    return View(model);
                }

                // Stoğun miktarını model nesnesine ekle
                stok.Miktar += model.Miktar;

                _context.Update(stok);
                _context.Add(model);
                _context.SaveChanges();

                return RedirectToAction("StokListele");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult StokListele()
        {
            List<StokGirdi> stokListesi = _context.StokGirdiler.Include(x => x.Tedarikci).ToList();
            ViewBag.Malzeme = _context.Malzemeler.ToList();

            return View(stokListesi);

        }
        public async Task<IActionResult> StokSil(int id)
        {
            var urun = await _context.Stoklar.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }

            urun.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("StokListele");
        }

    }
}
