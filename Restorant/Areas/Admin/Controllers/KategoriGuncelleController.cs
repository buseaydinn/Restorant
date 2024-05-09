using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KategoriGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public KategoriGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult KategoriGuncelle(int id)
        {
            ViewBag.Kategoriler = _context.Kategoriler.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var kategori = _context.Kategoriler.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (kategori == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(kategori);
        }
        [HttpPost]
        public IActionResult KategoriGuncelle(Kategori model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var kategori = _context.Kategoriler.FirstOrDefault(x => x.Id == model.Id);
            if (kategori == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(kategori);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("KategoriListele", "Kategori"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }


    }
}

    
