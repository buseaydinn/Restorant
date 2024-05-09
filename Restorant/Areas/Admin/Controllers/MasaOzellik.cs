using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasaOzellikController : Controller
    {

        private readonly IdentityDataContext _context;

        public MasaOzellikController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MasaOzellikEkle()
        {
            //ViewBag.Ozellik = _context.Ozellikler.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MasaOzellikEkle(Ozellik model, IFormFile? file)
        {
            ViewBag.Ozellik = _context.Ozellikler.ToList();

            if (ModelState.IsValid)
            {
                _context.Ozellikler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("MasaOzellikListele");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult MasaOzellikListele()
        {
            var ozellikler = _context.MasaOzellikler.Select(m => new Ozellik { /* Gerekli alanları atama */ }).ToList();
            return View(ozellikler);
        }

    }
}
