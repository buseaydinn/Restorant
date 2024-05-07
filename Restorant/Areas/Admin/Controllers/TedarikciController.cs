using Microsoft.AspNetCore.Mvc;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TedarikciController : Controller
    {
        private readonly IdentityDataContext _context;

        public TedarikciController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TedarikciEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TedarikciEkle(Tedarikci model, int id)
        {
            if (ModelState.IsValid)
            {
                _context.Tedarikciler.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("TedarikciListele");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult TedarikciListele()
        {
            List<Tedarikci> TedarikciListele = _context.Tedarikciler.ToList();

            // Verileri View'e gönder
            return View(TedarikciListele);
            
        }
        public async Task<IActionResult> TedarikciSil(int id)
        {
            var tedarikci = await _context.Tedarikciler.FindAsync(id);
            if (tedarikci == null)
            {
                return NotFound();
            }

            tedarikci.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("TedarikciListele");
        }

    }
}
