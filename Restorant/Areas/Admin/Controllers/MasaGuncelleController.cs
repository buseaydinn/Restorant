using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasaGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public MasaGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MasaGuncelle(int id)
        {
            ViewBag.Kategoriler = _context.Kategoriler.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var masa = _context.Masalar.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (masa == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(masa);
        }
        [HttpPost]
        public IActionResult MasaGuncelle(Masa model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var masa = _context.Masalar.FirstOrDefault(x => x.Id == model.Id);
            if (masa == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(masa);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("MasaListele", "Masa"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }
    }
}

   
