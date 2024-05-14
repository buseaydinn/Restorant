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
        public async Task<IActionResult> PersonelGuncelle(Personel model, int id, IFormFile? file)
        {
            if (file != null)
            {
                var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                var resimuzanti = Path.GetExtension(file.FileName);
                if (!uzanti.Contains(resimuzanti))
                {
                    ModelState.AddModelError("PersonelFotograf", "Geçerli bir fotoğraf formatı seçiniz. *jpg,jpeg,png");
                }

                var random = string.Format($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}");
                var resimyolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", random);
                using (var stream = new FileStream(resimyolu, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.Fotograf = random;
            

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

            }

            return RedirectToAction("PersonelListele", "Personel"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }



        public IActionResult RolGuncelle(int id)
        {
            ViewBag.Roller = _context.Roller.ToList();

            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var rol = _context.Roller.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (rol == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(rol);
        }
        [HttpPost]
        public IActionResult RolGuncelle(Rol model)
        {


            if (!ModelState.IsValid)
            {
                return View(model); // Geçersiz model ise formu tekrar gösterin.
            }

            var rol = _context.Roller.FirstOrDefault(x => x.Id == model.Id);
            if (rol == null)
            {
                return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
            }

            // Önceki soruguyu untracked yani takipsiz yapma
            var entry = _context.Entry(rol);
            entry.State = EntityState.Detached;
            _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
            _context.SaveChanges();

            return RedirectToAction("RolListele", "Personel"); // İşlem başarılıysa ana sayfaya yönlendirin.
        }

    }
}
