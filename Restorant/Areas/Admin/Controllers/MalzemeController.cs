using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;
namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MalzemeController : Controller
    {
        private readonly IdentityDataContext _context;

        public MalzemeController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MalzemeEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MalzemeEkle(Malzeme model, int id)
        {
            if (ModelState.IsValid)
            {
                model.Stok.Miktar = 0;
                model.Stok.Gorunurluk =true;
                _context.Malzemeler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("MalzemeListele");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult MalzemeListele()
        {
         var MalzemeListesi = _context.Malzemeler.Include(x=>x.Stok).ToList();
       


            // Verileri View'e gönder
            return View(MalzemeListesi);
        }
        public async Task<IActionResult> MalzemeSil(int id)
        {
            var malzeme = await _context.Malzemeler.FindAsync(id);
            if (malzeme == null)
            {
                return NotFound();
            }

            malzeme.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("MalzemeListele");
        }
    }
}
