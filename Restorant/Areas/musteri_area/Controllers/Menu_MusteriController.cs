using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("musteri_area")]
    public class Menu_MusteriController : Controller
    {
        private readonly IdentityDataContext _context;
        public Menu_MusteriController(IdentityDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Menuler = _context.Menuler.ToList();
            return View();
        }
    }
}
