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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StokEkle(Stok model, int id, IFormFile? file)
        {
            ViewBag.Tedarikci = _context.Tedarikciler.ToList();

            if (ModelState.IsValid)
            {
                _context.Stoklar.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult StokListele()
        {
            List<Stok> stokListesi = _context.Stoklar.Include(x => x.Tedarikci).ToList();


            return View(StokListele);

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
