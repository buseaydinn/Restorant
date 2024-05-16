using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunGuncelleController : Controller
    {

        private readonly IdentityDataContext _context;

        public UrunGuncelleController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UrunGuncelle(int id)
        {
            ViewBag.Kategori = _context.Kategoriler.ToList();
            ViewBag.Malzemeler = _context.Malzemeler.ToList();


            // IdentityDataContext.Personeller özelliğinden belirli bir personeli alın.
            var urun = _context.Urunler.FirstOrDefault(p => p.Id == id);

            // Eğer personel bulunamazsa 404 hatası döndürün.
            if (urun == null)
            {
                return NotFound();
            }

            // PersonelGuncelleModel oluştururken doğru personel nesnesini kullanın.
            return View(urun);
        }
        [HttpPost]
            public async Task<IActionResult> UrunGuncelle(Urun model, int id, IFormFile? file/*, List<int> malzemeler*/)
            {

                if (file != null)
                {
                    var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                    var resimuzanti = Path.GetExtension(file.FileName);
                    if (!uzanti.Contains(resimuzanti))
                    {
                        ModelState.AddModelError("UrunFotograf", "Geçerli bir fotoğraf formatı seçiniz. *jpg,jpeg,png");
                    }

                    var random = string.Format($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}");
                    var resimyolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", random);
                    using (var stream = new FileStream(resimyolu, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    model.Fotograf = random;


                    var urun = _context.Urunler.FirstOrDefault(x => x.Id == model.Id);
                    if (urun == null)
                    {
                        return NotFound(); // Eğer personel bulunamazsa 404 hatası döndürün.
                    }
                //foreach (var item in malzemeler)
                //{
                //    var urunmalzeme = new UrunMalzeme
                //    {
                //        Urun = model,
                //        MalzemeId = item,
                //        Gorunurluk = true,
                //    };
                //    _context.UrunMalzemeler.Add(urunmalzeme);
                //}
                // Önceki soruguyu untracked yani takipsiz yapma
                var entry = _context.Entry(urun);
                    entry.State = EntityState.Detached;
                    _context.Update(model); // Güncellenmiş personel bilgilerini kaydedin.
                    _context.SaveChanges();

                }

                return RedirectToAction("UrunListele", "Urun"); // İşlem başarılıysa ana sayfaya yönlendirin.
            }

        }
    }
