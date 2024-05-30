using System;
using System.Collections.Generic;
using Restorant.Data;

namespace Restorant.Models;

public partial class Siparis
{
    public int Id { get; set; }

    public DateOnly? Tarih { get; set; }
    public string Kullanıcı { get; set; }

    public int DurumId { get; set; }

    public int? MasaId { get; set; }
    public Adres? Adres { get; set; }

    public int? Tutar { get; set; }

    public int? AdresId { get; set; }



    public string? Not { get; set; }

    public bool Gorunurluk { get; set; }

    public Masa Masa { get; set; }

    public int? YorumId { get; set; }

    public int? MutfakId { get; set; }

    public Yorum? Yorum { get; set; }
    public  ICollection<Durum> Durumlars { get; set; } = new List<Durum>();

    public  Kasa? Kasa { get; set; }

    public  Mutfak? Mutfak { get; set; }

    public  ICollection<TeslimatSiparis> Teslimatsiparislers { get; set; } = new List<TeslimatSiparis>();


    public ICollection<SiparisMenu> SiparisMenuler { get; set; } = new List<SiparisMenu>();

    public ICollection<SiparisUrun> SiparisUrunler { get; set; } = new List<SiparisUrun>();

}
