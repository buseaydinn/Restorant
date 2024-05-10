using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RezervasyonController : Controller
    {
        private readonly IdentityDataContext _context;
        public RezervasyonController(IdentityDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RezervasyonEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RezervasyonEkle(Rezervasyon model, int id, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _context.Rezervasyonlar.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("RezervasyonListele");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult RezervasyonListele()
        {
            var RezervasyonListesi = _context.Rezervasyonlar.ToList();

            // Verileri View'e gönder
            return View(RezervasyonListesi);
        }
        public async Task<IActionResult> RezervasyonSil(int id)
        {
            var rezervasyon = await _context.Rezervasyonlar.FindAsync(id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            rezervasyon.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("RezervasyonListele");
        }

    }
}

