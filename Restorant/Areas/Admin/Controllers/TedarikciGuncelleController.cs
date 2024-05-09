using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TedarikciGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public TedarikciGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TedarikciGuncelle(int id)
        {
            ViewBag.Tedarikciler = _context.Tedarikciler.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var tedarikci = _context.Tedarikciler.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (tedarikci == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(tedarikci);
        }
        [HttpPost]
        public IActionResult TedarikciGuncelle(Tedarikci model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var tedarikci = _context.Tedarikciler.FirstOrDefault(x => x.Id == model.Id);
            if (tedarikci == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(tedarikci);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("TedarikciListele", "Tedarikci"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }


    }
}
