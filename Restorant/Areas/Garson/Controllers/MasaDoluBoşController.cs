using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Garson")]
    public class MasaDoluBoşController : Controller
    {

        private readonly IdentityDataContext _context;

        public MasaDoluBoşController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Masa> masaListesi = _context.Masalar.Include(x => x.Kategori).Include(x => x.masaozellikler).ThenInclude(x => x.Ozellik).ToList();

            return View(masaListesi);
        }
    }
}
