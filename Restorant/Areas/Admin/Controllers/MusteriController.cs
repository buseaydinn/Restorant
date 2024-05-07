using Microsoft.AspNetCore.Mvc;
using Restorant.Models;
namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MusteriController : Controller
    {
        private readonly IdentityDataContext _context;

        public MusteriController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MusteriEkle(Musteri model, int id)
        {
            if (ModelState.IsValid)
            {
                _context.Musteriler.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("MusteriListele");
            }
            else
            {
                return View(model);
            }
        }
            public IActionResult MusteriListele()
            {
                List<Musteri> musteriListesi = _context.Musteriler.ToList();

                // Verileri View'e gönder
                return View(musteriListesi);
            }

        public async Task<IActionResult> MusteriSil(int id)
        {
            var musteri = await _context.Musteriler.FindAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }

            musteri.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("MusteriListele");
        }

    }
    }

