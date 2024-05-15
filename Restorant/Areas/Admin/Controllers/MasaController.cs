using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using Restorant.Data;
using Restorant.Models;
using System.Drawing;

namespace Restorant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasaController : Controller
    {

        private readonly IdentityDataContext _context;

        public MasaController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MasaEkle()
        {
            //ViewBag.Masalar = _context.Masalar.ToList();
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            ViewBag.Personeller = _context.Personeller.ToList();
            ViewBag.Ozellikler = _context.Ozellikler.ToList();


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MasaEkle(Masa model, int id, IFormFile? file, List<int> MasaOzellik)
        {
            if (ModelState.IsValid)
            {
                string masaKod = model.Kod;
                string QrLink = $"https://deneme.com/{masaKod}";

                // QR kodu oluştur
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QrLink, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeImage = qrCode.GetGraphic(20);

                // QR kodunu wwwroot/img klasörüne kaydet
                string fileName = $"{model.Kod}.png"; // QR kodunun dosya adı olarak model.Kod kullanılıyor
                string filePath = Path.Combine("wwwroot/img", fileName); // Dosya yolunu oluştur
                System.IO.File.WriteAllBytes(filePath, qrCodeImage); // QR kodunu dosyaya kaydet

                // Modelin QR sütununa dosya yolunu ekleyin
                model.Qr = $"/img/{fileName}";

                foreach (var item in MasaOzellik)
                {
                    var masaozellik = new MasaOzellik
                    {
                        Masa = model,
                        OzellikId = item,
                        Gorunurluk = true,
                    };
                    _context.MasaOzellikler.Add(masaozellik);
                }

                _context.Masalar.Add(model);
                _context.Masalar.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("MasaListele");
            }
            else
            {
                return View(model);
            }
            
        }
        public IActionResult MasaListele()
        {
            List<Masa> masaListesi = _context.Masalar.Include(x => x.Kategori).Include(x => x.masaozellikler).ThenInclude(x => x.Ozellik).ToList();


            // Verileri View'e gönder
            return View(masaListesi);
        }
         public async Task<IActionResult> MasaSil(int id)
{
var masa = await _context.Menuler.FindAsync(id);
    if (masa == null)
    {
        return NotFound();
    }

    masa.Gorunurluk = false;
    await _context.SaveChangesAsync();

    return RedirectToAction("MasaListele");
}
    }
}
