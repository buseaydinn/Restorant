﻿using System;
using System.Collections.Generic;

namespace Restorant.Models;

public partial class Durum
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public DateTime? Zaman { get; set; }

    public string? Yer { get; set; }

    public int? SiparisId { get; set; }

    public  Siparis? Siparis { get; set; }
}
