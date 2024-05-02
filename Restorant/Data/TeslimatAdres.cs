using System;
using System.Collections.Generic;
using Restorant.Models;

namespace Restorant.Data;

public partial class TeslimatAdres
{
    public int Id { get; set; }

    public DateOnly? Tarih { get; set; }

    public int? MusteriId { get; set; }

    public bool? Gorunurluk { get; set; }

    public  Adres? Adres { get; set; }

    public  Musteri? Musteri { get; set; }
}
