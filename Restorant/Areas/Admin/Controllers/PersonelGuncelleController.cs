using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonelGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public PersonelGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonelGuncelle(int id)
        {
            ViewBag.Roller = _context.Roller.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var personel = _context.Personeller.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (personel == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(personel);
        }
        [HttpPost]
        public IActionResult PersonelGuncelle(Personel model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var personel = _context.Personeller.FirstOrDefault(x => x.Id == model.Id);
            if (personel == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(personel);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("PersonelListele", "Personel"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }   
    }
}
