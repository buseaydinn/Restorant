﻿using System;
using System.Collections.Generic;

namespace Restorant.Models;

public partial class Mutfak
{
    public int Id { get; set; }

    public  ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();

    public  ICollection<Siparis> Siparislers { get; set; } = new List<Siparis>();
}
