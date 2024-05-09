using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MalzemeGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public MalzemeGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MalzemeGuncelle(int id)
        {
            ViewBag.Malzemeler = _context.Malzemeler.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var malzeme = _context.Malzemeler.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (malzeme == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(malzeme);
        }
        [HttpPost]
        public IActionResult MalzemeGuncelle(Malzeme model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var malzeme = _context.Malzemeler.FirstOrDefault(x => x.Id == model.Id);
            if (malzeme == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(malzeme);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("MalzemeListele", "Malzeme"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }
    }
}

