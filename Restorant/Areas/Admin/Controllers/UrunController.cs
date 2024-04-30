using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urun model, int id)
        {
            if (ModelState.IsValid)
            {
                _context.Urunler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult UrunListele()
        {
            List<Urun> urunListesi = _context.Urunler.ToList();

            // Verileri View'e gönder
            return View(urunListesi);
        }
    }
}
