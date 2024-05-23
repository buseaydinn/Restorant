using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("musteri_area")]
    public class Sepet_MusteriController : Controller
    {
        private readonly IdentityDataContext _context;
        public Sepet_MusteriController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
