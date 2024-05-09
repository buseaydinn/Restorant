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
            ViewBag.Roller = _context.Roller.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PersonelEkle(Personel model, int id,IFormFile?file)
        {
            if (ModelState.IsValid)
            {
                _context.Personeller.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("PersonelListele");
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

        public async Task<IActionResult> PersonelSil(int id)
        {
            var personel = await _context.Personeller.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }

            personel.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("PersonelListele");
        }

        [HttpPost]
        public async Task<IActionResult> RolEkle(Rol model, int id)
        {
            if (ModelState.IsValid)
            {
                _context.Roller.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("RolListele");
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
        public async Task<IActionResult> RolSil(int id)
        {
            var rol = await _context.Roller.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            rol.Gorunurluk = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("RolListele");
        }
    }
    }
    

