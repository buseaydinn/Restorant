using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {

        private readonly IdentityDataContext _context;

        public MenuController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
         public IActionResult MenuEkle() 
        {
            ViewBag.Kategori = _context.Kategoriler.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MenuEkle(Menu model, int id,IFormFile?file)
        {
            ViewBag.Kategori = _context.Kategoriler.ToList();

            if (ModelState.IsValid)
            {
                _context.Menuler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult MenuListele()
        {
            List<Menu> menuListesi = _context.Menuler.Include(x => x.Kategori).ToList();

            // Verileri View'e gönder
            return View(menuListesi);
        }
    }
}
