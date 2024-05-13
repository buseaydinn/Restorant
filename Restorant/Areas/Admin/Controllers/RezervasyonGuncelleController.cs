using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RezervasyonGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public RezervasyonGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RezervasyonGuncelle(int id)
        {
            ViewBag.Masalar = _context.Masalar.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var masarezervasyon = _context.MasaRezervasyonlar.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (masarezervasyon == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(masarezervasyon);
        }
        [HttpPost]
        public IActionResult RezervasyonGuncelle(Musteri model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var masarezervasyon = _context.MasaRezervasyonlar.FirstOrDefault(x => x.Id == model.Id);
            if (masarezervasyon == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(masarezervasyon);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("RezervasyonListele", "MasaRezervasyon"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }
    }
}

