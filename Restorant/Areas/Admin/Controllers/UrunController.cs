using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Kategori = _context.Kategoriler.ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urun model, int id,IFormFile? file)
        {
          ViewBag.Kategori = _context.Kategoriler.ToList();

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                    var resimuzanti = Path.GetExtension(file.FileName);
                    if (!uzanti.Contains(resimuzanti))
                    {
                        ModelState.AddModelError("UrunFotograf", "Geçerli bir fotoğraf formatı seçiniz. *jpg,jpeg,png");
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
                        model.Fotograf = _context.Urunler
                            .Where(x => x.Id == model.Id)
                            .Select(x => x.Fotograf)
                            .FirstOrDefault();
                    }
                }



                _context.Urunler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("UrunListele");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult UrunListele()
        {
            List<Urun> urunListesi = _context.Urunler.Include(x => x.Kategori).ToList();

            // Verileri View'e gönder
            return View(urunListesi);
        }

        public async Task<IActionResult> UrunSil(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }

            urun.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("UrunListele");
        }




    }
}
