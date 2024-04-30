using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonelController : Controller
    {

        private readonly IdentityDataContext _context;

        public PersonelController(IdentityDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonelEkle() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PersonelEkle(Personel model, int id,IFormFile?file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                    var resimuzanti = Path.GetExtension(file.FileName);
                    if (!uzanti.Contains(resimuzanti))
                    {
                        ModelState.AddModelError("Fotograf", "Geçerli bir resim seçiniz. *jpg,jpeg,png");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("Fotograf", "Resim alanı boş olamaz");
               
                    return View(model);
                }

                var random = string.Format($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}");
                var resimyolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", random);
                using (var stream = new FileStream(resimyolu, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.Fotograf = random;
                _context.Personeller.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult PersonelListele()
        {
            List<Personel> personelListesi = _context.Personeller.ToList();

            // Verileri View'e gönder
            return View(personelListesi);
        }
        public IActionResult RolEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RolEkle(Rol model, int id)
        {
            if (ModelState.IsValid)
            {
                _context.Roller.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult RolListele()
        {
            List<Rol> rolListesi = _context.Roller.ToList();

            // Verileri View'e gönder
            return View(rolListesi);
        }
    }
    }
    

