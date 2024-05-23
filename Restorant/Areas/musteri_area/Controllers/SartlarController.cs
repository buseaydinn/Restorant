using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using Restorant.Models;
using System;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("musteri_area")]
    public class SartlarController : Controller
    {
        private readonly IdentityDataContext _context;
        public SartlarController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
