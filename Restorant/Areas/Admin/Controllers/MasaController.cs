using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasaController : Controller
    {

        private readonly IdentityDataContext _context;

        public MasaController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MasaEkle()
        {
            ViewBag.Masalar = _context.Masalar.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MasaEkle(Masa model, int id, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
               
                _context.Masalar.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

    }
}
