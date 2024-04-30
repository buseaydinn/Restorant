﻿using System;
using System.Collections.Generic;
using Restorant.Models;

namespace Restorant.Data;

public partial class TeslimatSiparis
{
    public int Id { get; set; }

    public DateOnly? OluşturmaTarihi { get; set; }

    public int? SiparisId { get; set; }

    public int? TeslimatId { get; set; }

    public int? MusteriId { get; set; }
    public bool? Gorunurluk { get; set; }

    public  Musteri? Musteri { get; set; }

    public  Siparis? Siparis { get; set; }

    public  Teslimat? Teslimat { get; set; }
}
