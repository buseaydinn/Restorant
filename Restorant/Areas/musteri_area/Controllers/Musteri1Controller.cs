using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("musteri_area")]
    public class Musteri1Controller : Controller
    {

        private readonly IdentityDataContext _context;

        public Musteri1Controller(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
