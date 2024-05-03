using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorant.Data;

public partial class Tedarikci
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]
    public string? AdSoyad { get; set; }

    public string? Firma{ get; set; }

      public string? Telefon { get; set; }

    public bool? Gorunurluk { get; set; } 

    public string Adres { get; set; } 

    public string? Eposta { get; set; }

    public  ICollection<StokGirdi> Stokgirdilers { get; set; } = new List<StokGirdi>();

    public  ICollection<Stok> Stoklars { get; set; } = new List<Stok>();
}
