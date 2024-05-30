using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restorant.Data;  // Assuming this contains IdentityDataContext
using Restorant.Models;
using System.Threading.Tasks;
using System.Linq;

public class SiparisViewComponent : ViewComponent
{
    private readonly IdentityDataContext _context;

    public SiparisViewComponent(IdentityDataContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var onaysizSiparisler = await _context.Siparisler
            .Where(x => (x.DurumId == 1 || x.DurumId == 4) && x.Gorunurluk)
            .ToListAsync();

        return View(onaysizSiparisler);
    }
}
