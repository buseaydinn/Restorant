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
        public IActionResult MenuGuncelle(Menu model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var menu = _context.Menuler.FirstOrDefault(x => x.Id == model.Id);
            if (menu == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(menu);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("MenuListele", "Menu"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }

    }
}




