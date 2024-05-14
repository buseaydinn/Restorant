using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StokGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public StokGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StokGuncelle(int id)
        {
            ViewBag.StokGirdi = _context.StokGirdiler.ToList();
            ViewBag.Malzeme = _context.Malzemeler.ToList();
            ViewBag.Tedarikci = _context.Tedarikciler.ToList();


            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var stok = _context.StokGirdiler.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (stok == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(stok);
        }
        [HttpPost]
        public IActionResult StokGuncelle(StokGirdi model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var stok = _context.StokGirdiler.FirstOrDefault(x => x.Id == model.Id);
            if (stok == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(stok);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("StokListele", "StokGirdi"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }

    }
}







