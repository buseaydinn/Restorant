using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorant.Data;

public partial class Tedarikci
{
    public int Id { get; set; }

    //[Required(ErrorMessage = "*Zorunlu alan")]
    public string? AdSoyad { get; set; }

    public string? Firma{ get; set; }

    //[Required(ErrorMessage = "*Zorunlu alan")]

    //[RegularExpression(@"^5\d{2} \d{3} \d{4}$", ErrorMessage = "*Geçerli bir telefon numarası giriniz (5xx xxx xxxx)")]
    public string? Telefon { get; set; }

    public bool? Gorunurluk { get; set; } 

    public string Adres { get; set; }


    [EmailAddress(ErrorMessage = "*Geçerli bir e-posta adresi giriniz")]
    public string? Eposta { get; set; }

    public  ICollection<StokGirdi> Stokgirdilers { get; set; } = new List<StokGirdi>();

    public  ICollection<Stok> Stoklars { get; set; } = new List<Stok>();
}
