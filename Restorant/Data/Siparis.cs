using System;
using System.Collections.Generic;
using Restorant.Data;

namespace Restorant.Models;

public partial class Siparis
{
    public int Id { get; set; }

    public DateOnly? Tarih { get; set; }

    public Adres? Adres { get; set; }

    public int? Tutar { get; set; }

    public string? OdemeDurum { get; set; }

    public string? Not { get; set; }

    public int? YorumId { get; set; }

    public int? AdresId { get; set; }

    public bool? Gorunurluk { get; set; }

    public int? MutfakId { get; set; }

    public Yorum? Yorum { get; set; }
    public  ICollection<Durum> Durumlars { get; set; } = new List<Durum>();

    public  Kasa? Kasa { get; set; }

    public  Mutfak? Mutfak { get; set; }

    public  ICollection<TeslimatSiparis> Teslimatsiparislers { get; set; } = new List<TeslimatSiparis>();

    public  ICollection<Odeme> Odemeler { get; set; } = new List<Odeme>();
   
   

}
