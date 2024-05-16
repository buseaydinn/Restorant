using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;
namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuIndirimController : Controller
    {
        private readonly IdentityDataContext _context;

        public MenuIndirimController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MenuIndirimEkle(int id)
        {
            var menu = _context.Menuler.FirstOrDefault(p => p.Id == id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }


        [HttpPost]
        public async Task<IActionResult> MenuIndirimEkle(Menu model, int id)
        {
            ViewBag.Kategori = _context.Kategoriler.ToList();
         

            _context.Menuler.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("MenuListele", "Menu");
        }
    }
}