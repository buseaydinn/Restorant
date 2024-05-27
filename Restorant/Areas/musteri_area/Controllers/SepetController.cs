using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;
using System;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("musteri_area")]
    public class SepetController : Controller
    {
        private readonly IdentityDataContext _context;
        public SepetController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Urunler = _context.Urunler.ToList();
            return View();
        }
    }
}
