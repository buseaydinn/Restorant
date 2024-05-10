using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasaOzellikGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public MasaOzellikGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult MasaOzellikGuncelle(int id)
        {
            ViewBag.Ozellikler = _context.Ozellikler.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var ozellik = _context.Ozellikler.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (ozellik == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(ozellik);
        }
        [HttpPost]
        public IActionResult MasaOzellikGuncelle(Ozellik model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var ozellik = _context.Ozellikler.FirstOrDefault(x => x.Id == model.Id);
            if (ozellik == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(ozellik);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("MasaOzellikListele", "MasaOzellik"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }
    }
}

