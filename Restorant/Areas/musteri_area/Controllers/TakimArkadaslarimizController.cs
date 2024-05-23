using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("musteri_area")]
    public class TakimArkadaslarimizController : Controller
    {
        private readonly IdentityDataContext _context;
        public TakimArkadaslarimizController(IdentityDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Personeller = _context.Personeller.Include(p => p.Rol).ToList();

            return View();
        }
    }
}
