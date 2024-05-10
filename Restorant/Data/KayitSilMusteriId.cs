using System;
using System.Collections.Generic;
using Restorant.Data;

namespace Restorant.Models;
public class KayitSilMusteriId
    {
    public int Id { get; set; }

    public string? Ad { get; set; }

    public string? Telefon { get; set; }

    public int RezervasyonId { get; set; }

    public bool? Gorunurluk { get; set; }

}

