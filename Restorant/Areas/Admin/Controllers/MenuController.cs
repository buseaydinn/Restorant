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
            ViewBag.Urunler = _context.Urunler.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MenuEkle(Menu model, int id, IFormFile? file)
        {
            ViewBag.Kategori = _context.Kategoriler.ToList();
            ViewBag.Urunler = _context.Urunler.ToList();

            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                    var resimuzanti = Path.GetExtension(file.FileName);
                    if (!uzanti.Contains(resimuzanti))
                    {
                        ModelState.AddModelError("MenuFotograf", "Geçerli bir fotoğraf formatı seçiniz. *jpg,jpeg,png");
                    }

                    var random = string.Format($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}");
                    var resimyolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", random);
                    using (var stream = new FileStream(resimyolu, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    model.Fotograf = random;
                }
                else
                {
                    if (model.Id != 0)
                    {
                        model.Fotograf = _context.Menuler
                            .Where(x => x.Id == model.Id)
                            .Select(x => x.Fotograf)
                            .FirstOrDefault();
                    }
                }

                _context.Menuler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("MenuListele");
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

        public async Task<IActionResult> MenuSil(int id)
        {
            var menu = await _context.Menuler.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            menu.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("MenuListele");
        }
    }
}