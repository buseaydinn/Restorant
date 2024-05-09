using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MusteriGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public MusteriGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MusteriGuncelle(int id)
        {
            ViewBag.Musteriler = _context.Musteriler.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var musteri = _context.Musteriler.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (musteri == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(musteri);
        }
        [HttpPost]
        public IActionResult MusteriGuncelle(Musteri model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var musteri = _context.Musteriler.FirstOrDefault(x => x.Id == model.Id);
            if (musteri == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(musteri);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("MusteriListele", "Musteri"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }
    }
}

  
