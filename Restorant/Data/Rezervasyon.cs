using System;
using System.Collections.Generic;

namespace Restorant.Models;

public partial class Rezervasyon
{
    public int Id { get; set; }

    public DateOnly? Tarih { get; set; }

    public int? KisiSayisi { get; set; }

    public bool? Gorunurluk { get; set; }

    public string? Talep { get; set; }

    public string? Onay { get; set; }

    public int MusteriId { get; set; }

    public string? KayisizMusteriId { get; set; }

    public DateOnly? TalepTarihi { get; set; }
    public TimeOnly? BaslangicSaati { get; set; }

    public TimeOnly? BitisSaati { get; set; }
}
