using System;
using System.Collections.Generic;

namespace Restorant.Models;

public partial class SiparisMenu
{

    public int Id { get; set; }

    public int? Miktar { get; set; }
    public float Fiyat { get; set; }
    public int MenuId { get; set; }

    public bool? Gorunurluk { get; set; }

    public int SiparisId { get; set; }

    public Menu Menu { get; set; } = null!;

    public  Siparis Siparis { get; set; } = null!;
 

    public int? YorumId { get; set; }

    public string? Detay { get; set; }

}


