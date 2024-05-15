using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;
namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IndirimController : Controller
    {
        private readonly IdentityDataContext _context;

        public IndirimController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
         
            return View();
        }

      
        public IActionResult IndirimEkle(int id)
        {
            var urun = _context.Urunler.FirstOrDefault(p => p.Id == id);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }


        [HttpPost]
        public async Task<IActionResult> IndirimEkle(Urun model, int id)
        {

            return View(model);
        }
    }
}
        
