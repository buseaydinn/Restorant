using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Garson")]
    public class SepetgosterController : Controller
    {

        private readonly IdentityDataContext _context;

        public SepetgosterController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Sepet> sepetListesi = _context.Sepetler.ToList();

            // Verileri View'e gönder
            return View(sepetListesi);
        }
    }
}
