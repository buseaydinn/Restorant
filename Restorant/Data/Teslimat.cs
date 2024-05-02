using System;
using System.Collections.Generic;
using Restorant.Models;

namespace Restorant.Data;

public partial class Teslimat
{
    public int Id { get; set; }

    public DateTime? Cıkıs { get; set; }

    public DateTime? Varis { get; set; }

    public string? OdemeDurum { get; set; }

    public string? TeslimDurum { get; set; }

    public bool? Gorunurluk { get; set; }

    public int? PersonelId { get; set; }

    public  Personel? Personel { get; set; }

    public  ICollection<TeslimatSiparis> Teslimatsiparislers { get; set; } = new List<TeslimatSiparis>();
}
