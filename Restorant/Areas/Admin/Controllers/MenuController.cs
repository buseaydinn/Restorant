using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Menuler = _context.Menuler.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MenuEkle(Menu model, int id,IFormFile?file)
        {
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
            List<Menu> menuListesi = _context.Menuler.ToList();

            // Verileri View'e gönder
            return View(menuListesi);
        }
    }
}
