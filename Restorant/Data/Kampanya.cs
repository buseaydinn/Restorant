﻿using System;
using System.Collections.Generic;

namespace Restorant.Models;

public partial class Kampanya
{
    public int Id { get; set; }

    public string? Kod { get; set; }

    public int? Indirim { get; set; }

    public DateTime? GecerlilikTarihi { get; set; }

    public bool? Durum { get; set; }

    //public bool? Gorunurluk { get; set; }
    public int? MusteriId { get; set; }

    public  Musteri? Musteri { get; set; }
}
