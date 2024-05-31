using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Mutfak")]
    public class GelenSiparisController : Controller
    {

        private readonly IdentityDataContext _context;

        public GelenSiparisController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Sepet> sepetListesi = _context.Sepetler.ToList();

            return View(sepetListesi);
        }
    }
}
