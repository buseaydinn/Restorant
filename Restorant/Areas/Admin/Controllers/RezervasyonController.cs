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
            ViewBag.Masalar = _context.Masalar.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult RezervasyonEkle(MasaRezervasyon model)
        {
            if (ModelState.IsValid)
            {
                _context.MasaRezervasyonlar.Add(model);
                _context.SaveChanges();
                return RedirectToAction("RezervasyonListele");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult RezervasyonListele()
        {
            List<MasaRezervasyon> masaRezervasyonListesi = _context.MasaRezervasyonlar.Include(x=>x.Rezervasyon).ToList();
            return View(masaRezervasyonListesi);
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

