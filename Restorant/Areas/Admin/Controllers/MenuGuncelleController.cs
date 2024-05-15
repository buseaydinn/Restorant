using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public MenuGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MenuGuncelle(int id)
        {
            ViewBag.Kategori = _context.Kategoriler.ToList();
            ViewBag.Urunler = _context.Urunler.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var menu = _context.Menuler.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (menu == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(menu);
        }
        [HttpPost]
        public async Task<IActionResult> MenuGuncelle(Menu model, int id, IFormFile? file, List<int> urunler)
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


                var menu = _context.Menuler.FirstOrDefault(x => x.Id == model.Id);
                if (menu == null)
                {
                    return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
                }
                foreach (var item in urunler)
                {
                    var menuurun = new MenuUrun
                    {
                        Menu = model,
                        UrunId = item,
                        Gorunurluk = true,
                    };
                    _context.MenuUrunler.Add(menuurun);
                }
                // Önceki soruguyu untracked yani takipsiz yapma
                var entry = _context.Entry(menu);
                entry.State = EntityState.Detached;
                _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
                _context.SaveChanges();

            }

            return RedirectToAction("MenuListele", "Menu"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }

    }
}




